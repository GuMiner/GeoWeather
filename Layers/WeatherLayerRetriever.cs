using BotCommon;
using BotCommon.Storage;
using BotCommon.Activity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace GeoWeather
{
    public class WeatherLayerRetriever
    {
        private readonly IStore blobStore;
        
        public WeatherLayerRetriever(IStore blobStore)
        {
            this.blobStore = blobStore;
        }

        public async Task<AttachmentResponse> GetRadarImageAsync(StationCallsigns station, List<RadarLayer> layers)
        {
            List<Image> images = new List<Image>();
            foreach (RadarLayer layer in layers)
            {
                Image image = await this.GetImageAsync(RadarLayerUtils.GetRadarLayerUri(station, layer)).ConfigureAwait(false);
                if (image != null)
                {
                    images.Add(image);
                }
            }

            Image compositeImage = RadarLayerUtils.OverlayImages(images);

            string blobId = DateTime.UtcNow.ToString("o");
            await blobStore.CreateOrUpdateAsync("weather-images", blobId, (stream) => { compositeImage.Save(stream, ImageFormat.Png); return Task.CompletedTask; }).ConfigureAwait(false);

            string uri = await blobStore.GetBlobSasUriAsync("weather-images", blobId, TimeSpan.FromDays(30*3)).ConfigureAwait(false);
            return new AttachmentResponse(uri, "image/png", $"{station.ToString().ToUpper()} weather");
        }

        public async Task<Image> GetImageAsync(string uri)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
                {
                    requestMessage.Headers.Add("User-Agent", "Custom-Agent");

                    HttpResponseMessage response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return Image.FromStream(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
                    }

                    throw new Exception(uri + " " + response.StatusCode + " " + await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                }
            }
        }
    }
}
