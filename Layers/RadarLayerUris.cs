using GeoWeather.Properties;

namespace GeoWeather.Layers
{
    /// <summary>
    /// Defines how to retrieve URIs for NOAA radar layers
    /// </summary>
    public static class RadarLayerUris
    {
        /// <summary>
        /// Given a station callsign and layer type, returns the URI to retrieve that weather image for that station.
        /// </summary>
        public static string GetRadarLayerUri(string stationCallsign, RadarLayerType layer)
        {
            switch (layer)
            {
                case RadarLayerType.BaseReflectivity: return $"{Settings.Default.RadarBaseUri}{Settings.Default.BaseReflectivityFormatString}";
                case RadarLayerType.StormRelativeMotion: return $"{Settings.Default.RadarBaseUri}{Settings.Default.StormRelativeMotionFormatString}";
                case RadarLayerType.OneHourPrecipitation: return $"{Settings.Default.RadarBaseUri}{Settings.Default.OneHourPrecipitationFormatString}";

                case RadarLayerType.Topography: return $"{Settings.Default.OverlayBaseUri}{Settings.Default.TopographyFormatString}";
                case RadarLayerType.CountyBoundaries: return $"{Settings.Default.OverlayBaseUri}{Settings.Default.CountyBoundariesFormatString}";
                case RadarLayerType.Rivers: return $"{Settings.Default.OverlayBaseUri}{Settings.Default.RiversFormatString}";
                case RadarLayerType.Highways: return $"{Settings.Default.OverlayBaseUri}{Settings.Default.HighwaysFormatString}";
                case RadarLayerType.Cities: return $"{Settings.Default.OverlayBaseUri}{Settings.Default.CitiesFormatString}";
                default: return string.Empty;
            }
        }
    }
}
