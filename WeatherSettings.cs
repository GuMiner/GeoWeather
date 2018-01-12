using GeoWeather.Layers;
using GeoWeather.Stations;
using System.Linq;

namespace GeoWeather
{
    /// <summary>
    /// Defines settings for retrieving weather data.
    /// </summary>
    public class WeatherSettings
    {
        /// <summary>
        /// Creates a new <see cref="WeatherSettings"/> with reasonable defaults.
        /// </summary>
        public WeatherSettings()
        {
            this.Station = KnownStations.Stations.First().Callsign;
            this.LayerStack = new LayerStack();
        }

        /// <summary>
        /// Gets the station currently set
        /// </summary>
        public string Station { get; set; }
        
        /// <summary>
        /// Gets the stack of radar layers that should be displayed
        /// </summary>
        public LayerStack LayerStack { get; set; }
    }
}
