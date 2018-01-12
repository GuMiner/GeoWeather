using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GeoWeather
{
    public enum RadarLayer
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

    public class RadarLayerUtils
    {
        private const string RadarBaseUri = "https://radar.weather.gov/ridge/RadarImg/";
        private const string OverlayBaseUri = "https://radar.weather.gov/ridge/Overlays/";
        
        public static string GetRadarLayerUri(StationCallsigns station, RadarLayer layer)
        {
            string stationString = station.ToString().ToUpper();
            switch(layer)
            {
                case RadarLayer.BaseReflectivity: return $"{RadarBaseUri}N0R/{stationString}_N0R_0.gif";
                case RadarLayer.StormRelativeMotion: return $"{RadarBaseUri}N0S/{stationString}_N0S_0.gif";
                case RadarLayer.OneHourPrecipitation: return $"{RadarBaseUri}N1P/{stationString}_N1P_0.gif";

                case RadarLayer.Topography: return $"{OverlayBaseUri}Topo/Short/{stationString}_Topo_Short.jpg";
                case RadarLayer.CountyBoundaries: return $"{OverlayBaseUri}County/Short/{stationString}_County_Short.gif";
                case RadarLayer.Rivers: return $"{OverlayBaseUri}Rivers/Short/{stationString}_Rivers_Short.gif";
                case RadarLayer.Highways: return $"{OverlayBaseUri}Highways/Short/{stationString}_Highways_Short.gif";
                case RadarLayer.Cities: return $"{OverlayBaseUri}Cities/Short/{stationString}_City_Short.gif";
                default: throw new Exception("Expected to retrieve a URI for this layer!");
            }
        }

        public static Image OverlayImages(List<Image> images)
        {
            int maxWidth = images.Any() ? images.Max(image => image.Width) : 128;
            int maxHeight = images.Any() ? images.Max(image => image.Height) : 128;
            Image composite = new Bitmap(maxWidth, maxHeight);
            using (Graphics gr = Graphics.FromImage(composite))
            {
                foreach (Image image in images)
                {
                    gr.DrawImage(image, 0, 0);
                }

                if (!images.Any())
                {
                    gr.DrawEllipse(Pens.AliceBlue, 16, 16, 96, 96);
                }
            }

            return composite;
        }

        public static RadarLayer GetLayer(string name)
        {
            switch (name)
            {
                case "base radar":
                    return RadarLayer.BaseReflectivity;
                case "storm relative motion":
                    return RadarLayer.StormRelativeMotion;
                case "rain":
                    return RadarLayer.OneHourPrecipitation;
                case "topography":
                    return RadarLayer.Topography;
                case "county boundaries":
                    return RadarLayer.CountyBoundaries;
                case "rivers":
                    return RadarLayer.Rivers;
                case "highways":
                    return RadarLayer.Highways;
                case "cities":
                    return RadarLayer.Cities;
                default:
                    return RadarLayer.Unknown;
            }
        }

        public static string GetFriendlyName(RadarLayer layer)
        {
            switch(layer)
            {
                case RadarLayer.BaseReflectivity:
                    return "Base Radar";
                case RadarLayer.StormRelativeMotion:
                    return "Storm Relative Motion";
                case RadarLayer.OneHourPrecipitation:
                    return "Rain (one-hour precipitation)";
                case RadarLayer.Topography:
                    return "Topography";
                case RadarLayer.CountyBoundaries:
                    return "County Boundaries";
                case RadarLayer.Rivers:
                    return "Rivers";
                case RadarLayer.Highways:
                    return "Highways";
                case RadarLayer.Cities:
                    return "Cities";
                default:
                    return "Unknown layer";
            }
        }

        public static string GetAllLayerNames()
        {
            List<string> lines = new List<string>();
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.BaseReflectivity));
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.StormRelativeMotion));
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.OneHourPrecipitation));
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.Topography));
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.CountyBoundaries));
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.Rivers));
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.Highways));
            lines.Add(RadarLayerUtils.GetFriendlyName(RadarLayer.Cities));

            return string.Join(", ", lines);
        }
    }
}