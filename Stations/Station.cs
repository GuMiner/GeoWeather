using System.Device.Location;

namespace GeoWeather.Stations
{
    /// <summary>
    /// Lists detailed information about a NOAA weather station.
    /// </summary>
    public class Station
    {
        public Station(string callsign, string city, double latitude, double longitude)
        {
            this.Callsign = callsign;
            this.City = city;
            this.Location = new GeoCoordinate(latitude, longitude);
        }

        /// <summary>
        /// Gets the callsign of a NOAA weather station.
        /// </summary>
        public string Callsign { get; }

        /// <summary>
        /// Gets the city, with state postal code, of the NOAA weather station.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets the location of the weather station.
        /// </summary>
        public GeoCoordinate Location { get; }
    }
}
