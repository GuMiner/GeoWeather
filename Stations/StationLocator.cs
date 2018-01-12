using MoreLinq;
using System.Device.Location;

namespace GeoWeather.Stations
{
    /// <summary>
    /// Defines methods for locating NOAA weather stations.
    /// </summary>
    public static class StationLocator
    {
        /// <summary>
        /// Finds the closest station to the <paramref name="requestedLocation"/>.
        /// </summary>
        public static Station FindClosestStation(GeoCoordinate requestedLocation)
            => KnownStations.Stations.MinBy(station => station.Location.GetDistanceTo(requestedLocation));
    }
}
