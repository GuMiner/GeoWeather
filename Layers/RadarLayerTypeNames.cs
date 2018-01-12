using System.Collections.Generic;

namespace GeoWeather.Layers
{
    /// <summary>
    /// Defines utility functions for converting <see cref="RadarLayerType"/>s to human-friendly names.
    /// </summary>
    public static class RadarLayerTypeNames
    {
        /// <summary>
        /// Given the human friendly <paramref name="name"/>, returns the matching <see cref="RadarLayerType"/>
        /// </summary>
        public static RadarLayerType GetLayer(string name)
        {
            switch (name)
            {
                case "base radar":
                    return RadarLayerType.BaseReflectivity;
                case "storm relative motion":
                    return RadarLayerType.StormRelativeMotion;
                case "rain":
                    return RadarLayerType.OneHourPrecipitation;
                case "topography":
                    return RadarLayerType.Topography;
                case "county boundaries":
                    return RadarLayerType.CountyBoundaries;
                case "rivers":
                    return RadarLayerType.Rivers;
                case "highways":
                    return RadarLayerType.Highways;
                case "cities":
                    return RadarLayerType.Cities;
                default:
                    return RadarLayerType.Unknown;
            }
        }

        /// <summary>
        /// Given the <paramref name="layer"/> type, returns a human-friendly name.
        /// </summary>
        public static string GetFriendlyName(RadarLayerType layer)
        {
            switch(layer)
            {
                case RadarLayerType.BaseReflectivity:
                    return "Base Radar";
                case RadarLayerType.StormRelativeMotion:
                    return "Storm Relative Motion";
                case RadarLayerType.OneHourPrecipitation:
                    return "Rain (one-hour precipitation)";
                case RadarLayerType.Topography:
                    return "Topography";
                case RadarLayerType.CountyBoundaries:
                    return "County Boundaries";
                case RadarLayerType.Rivers:
                    return "Rivers";
                case RadarLayerType.Highways:
                    return "Highways";
                case RadarLayerType.Cities:
                    return "Cities";
                default:
                    return "Unknown layer";
            }
        }

        /// <summary>
        /// Gets all layer names, deliminated by a comma and a space.
        /// </summary>
        public static string GetAllLayerNames()
        {
            List<string> lines = new List<string>();
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.BaseReflectivity));
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.StormRelativeMotion));
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.OneHourPrecipitation));
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.Topography));
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.CountyBoundaries));
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.Rivers));
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.Highways));
            lines.Add(RadarLayerTypeNames.GetFriendlyName(RadarLayerType.Cities));

            return string.Join(", ", lines);
        }
    }
}