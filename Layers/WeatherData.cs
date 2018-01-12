using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoWeather
{
    public class WeatherData
    {
        public WeatherData()
        {
            this.Station = StationCallsigns.ATX;
            this.RadarLayers = new List<RadarLayer>()
            {
                RadarLayer.Topography,
                RadarLayer.BaseReflectivity
            };
        }

        public StationCallsigns Station { get; set; }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public List<RadarLayer> RadarLayers { get; set; }

        public void AddLayer(RadarLayer layer, List<string> responseText)
        {
            if (this.RadarLayers.Contains(layer))
            {
                responseText.Add($"The '{layer.ToString()}' layer has already been added for rendering.");
            }
            else
            {
                this.RadarLayers.Add(layer);
            }
        }

        public void RemoveLayer(RadarLayer layer, List<string> responseText)
        {
            if (!this.RadarLayers.Contains(layer))
            {
                responseText.Add($"The '{layer.ToString()}' layer has already been removed from rendering.");
            }
            else
            {
                this.RadarLayers.Remove(layer);
            }
        }

        public void PromoteLayer(RadarLayer layer, List<string> responseText)
        {
            if (!this.RadarLayers.Contains(layer))
            {
                responseText.Add($"The '{layer.ToString()}' layer is not listed for rendering.");
            }
            else
            {
                int idx = this.RadarLayers.IndexOf(layer);
                if (idx != 0)
                {
                    this.RadarLayers.Remove(layer);
                    this.RadarLayers.Insert(idx - 1, layer);
                }
            }
        }

        public void DemoteLayer(RadarLayer layer, List<string> responseText)
        {
            if (!this.RadarLayers.Contains(layer))
            {
                responseText.Add($"The '{layer.ToString()}' layer is not listed for rendering.");
            }
            else
            {
                int idx = this.RadarLayers.IndexOf(layer);
                if (idx != this.RadarLayers.Count - 1)
                {
                    this.RadarLayers.Remove(layer);
                    this.RadarLayers.Insert(idx + 1, layer);
                }
            }
        }
    }
}
