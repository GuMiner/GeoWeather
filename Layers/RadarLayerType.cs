namespace GeoWeather.Layers
{
    /// <summary>
    /// Defines types of radar layers we can retrieve from the NOAA https://radar.weather.gov/ site.
    /// </summary>
    public enum RadarLayerType
    {
        // NOAA Ridge graphics
        BaseReflectivity,
        StormRelativeMotion,
        OneHourPrecipitation,

        // NOAA overlays
        Topography,
        CountyBoundaries,
        Rivers,
        Highways,
        Cities,
        Unknown
    }
}
