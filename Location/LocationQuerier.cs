using BotCommon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GeoWeather
{
    public class LocationData
    {
        public List<ResourceSet> ResourceSets { get; set; }
    }

    public class ResourceSet
    {
        public List<Resource> Resources { get; set; }
    }

    public class Resource
    {
        public Point Point { get; set; }
    }

    public class Point
    {
        public List<double> Coordinates { get; set; }
    }

    public class LocationQuerier
    {
        private const string LocationFormatString = "http://dev.virtualearth.net/REST/v1/Locations/{0}?o=json&key={1}";
        private readonly string apiKey;

        public LocationQuerier(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<GeoCoordinate> GetLocationAsync(string query)
        {
            string urlEncodedQuery = HttpUtility.UrlEncode(query);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage result = 
                    await client.GetAsync(string.Format(LocationQuerier.LocationFormatString, urlEncodedQuery, this.apiKey)).ConfigureAwait(false);

                string readMessage = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                LocationData data = JsonConvert.DeserializeObject<LocationData>(readMessage);
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
