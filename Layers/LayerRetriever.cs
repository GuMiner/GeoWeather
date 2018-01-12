using BotCommon.Storage;
using BotCommon.Activity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace GeoWeather.Layers
{
    /// <summary>
    /// Defines methods for retrieving image layers.
    /// </summary>
    public static class LayerRetriever
    {
        private const string PngMimeType = "image/png";

        /// <summary>
        /// Given <see cref="WeatherSettings"/>, retrieves radar images, overlays them, saves them in the <see cref="IStore"/> under the specified container, and
        /// returns an <see cref="AttachmentResponse"/> with an SAS URI that will expire after <paramref name="sasUriExpiration"/>
        /// </summary>
        /// <param name="settings">The settings to use to determine what images to retrieve.</param>
        /// <param name="blobStore">The storage to use to store images for later retrieval.</param>
        /// <param name="blobContainer">The container in the storage to store the image blobs in.</param>
        /// <param name="sasUriExpiration">The time that the blobs should expire in after <see cref="DateTime.UtcNow"/></param>
        /// <returns>A response with a SAS URI to access the images in PNG format.</returns>
        public static async Task<AttachmentResponse> GetRadarImageAsync(WeatherSettings settings, IStore blobStore, string blobContainer, TimeSpan sasUriExpiration)
        {
            List<Image> images = new List<Image>();
            foreach (RadarLayerType layer in settings.LayerStack.RadarLayers)
            {
                Image image = await LayerRetriever.GetImageAsync(RadarLayerUris.GetRadarLayerUri(settings.Station, layer)).ConfigureAwait(false);
                if (image != null)
                {
                    images.Add(image);
                }
            }

            Image compositeImage = ImageUtils.OverlayImages(images);

            string blobId = $"{DateTime.UtcNow.ToString("o")}-{Guid.NewGuid()}";
            await blobStore.CreateOrUpdateAsync(blobContainer, blobId, (stream) => { compositeImage.Save(stream, ImageFormat.Png); return Task.CompletedTask; }).ConfigureAwait(false);

            string uri = await blobStore.GetBlobSasUriAsync(blobContainer, blobId, sasUriExpiration).ConfigureAwait(false);
            return new AttachmentResponse(uri, LayerRetriever.PngMimeType, $"{settings.Station.ToUpper()} weather");
        }

        /// <summary>
        /// Given a URI from <see cref="RadarLayerUris.GetRadarLayerUri(string, RadarLayerType)"/>, returns the image retrived from that URI.
        /// </summary>
        /// <exception cref="InvalidOperationException">If we did not recieve <see cref="HttpStatusCode.OK"/> from the endpoint.</exception>
        /// <exception cref="ArgumentException">If the response returned from the endpoint is not a valid image stream.</exception>
        public static async Task<Image> GetImageAsync(string radarLayerUri)
        {
            // Ensure we have all TLS protocols enabled, in priority order.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, radarLayerUri))
                {
                    // The NOAA weather site requires an agent field or it will not return a valid response.
                    requestMessage.Headers.Add("User-Agent", "Custom-Agent");

                    HttpResponseMessage response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return Image.FromStream(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
                    }

                    throw new InvalidOperationException(radarLayerUri + " " + response.StatusCode + " " + await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                }
            }
        }
    }
}
