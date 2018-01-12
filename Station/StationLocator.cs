using System;
using System.Collections.Generic;
using System.Device.Location;

namespace GeoWeather
{
    public class StationLocator
    {
        public static Tuple<StationCallsigns, double> FindClosestStation(GeoCoordinate requestedLocation)
        {
            StationCallsigns closestStation = StationCallsigns.ATX;
            double distance = double.MaxValue;
            
            foreach (KeyValuePair<StationCallsigns, StationData> data in StationData.Data)
            {
                double distanceToStation = data.Value.Location.GetDistanceTo(requestedLocation);
                if (distanceToStation < distance)
                {
                    distance = distanceToStation;
                    closestStation = data.Key;
                }
            }

            return Tuple.Create(closestStation, distance);
        }
    }
}
