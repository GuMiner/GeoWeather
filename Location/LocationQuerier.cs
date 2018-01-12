using GeoWeather.Properties;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace GeoWeather.Location
{
    /// <summary>
    /// Defines functionality to retrieve <see cref="GeoCoordinate"/>s from human-friendly location queries.
    /// </summary>
    public class LocationQuerier
    {
        private readonly string apiKey;

        /// <summary>
        /// Creates a new <see cref="LocationQuerier"/>.
        /// </summary>
        /// <param name="apiKey">The access key to use to retrieve location data. You can get an API key at https://msdn.microsoft.com/en-us/library/ff428642.aspx </param>
        public LocationQuerier(string apiKey)
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Given a human-friendly location <paramref name="query"/>, such as "NYC", "Boulder, CO", etc, retrieves a machine-friendly <see cref="GeoCoordinate"/>
        /// </summary>
        /// <exception cref="InvalidDataException">If the <paramref name="query"/> was unable to be parsed to a <see cref="GeoCoordinate"/></exception>
        public async Task<GeoCoordinate> GetLocationAsync(string query)
        {
            string urlEncodedQuery = HttpUtility.UrlEncode(query);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(
                    string.Format(Settings.Default.LocationQueryUriFormatString, urlEncodedQuery, this.apiKey)).ConfigureAwait(false);

                string readMessage = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                LocationDataTypes.Resources data = JsonConvert.DeserializeObject<LocationDataTypes.Resources>(readMessage);
                List<double> coords = data?.ResourceSets?.FirstOrDefault()?.Resources?.FirstOrDefault()?.Point?.Coordinates ?? null;
                if (coords.Count == 2)
                {
                    return new GeoCoordinate(coords[0], coords[1]);
                }

                throw new InvalidDataException(readMessage);
            }
        }
    }
}
