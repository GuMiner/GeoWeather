using System.Collections.Generic;

namespace GeoWeather.Location
{
    /// <summary>
    /// Defines data types used for location deserialziation
    /// </summary>
    internal class LocationDataTypes
    {
        public class Resources
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
    }
}
