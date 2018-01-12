using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeoWeather.Layers
{
    /// <summary>
    /// Defines a series of layers and their stacking arrangement.
    /// </summary>
    public class LayerStack
    {
        /// <summary>
        /// Creates a new layer stack with reasonable radar layer defaults.
        /// </summary>
        public LayerStack()
        {
            this.RadarLayers = new List<RadarLayerType>()
            {
                RadarLayerType.Topography,
                RadarLayerType.BaseReflectivity
            };
        }

        /// <summary>
        /// Gets the radar layers in preferred drawing order
        /// </summary>
        /// <remarks>
        /// We use <see cref="ObjectCreationHandling.Replace"/> such that </remarks>
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public List<RadarLayerType> RadarLayers { get; }

        /// <summary>
        /// Adds the specified <paramref name="layer"/> to the end of the stack. Returns an empty string, but if already present, returns an error message.
        /// </summary>
        public string AddLayer(RadarLayerType layer)
        {
            if (this.RadarLayers.Contains(layer))
            {
                return $"The '{layer.ToString()}' layer has already been added for rendering.";
            }
            else
            {
                this.RadarLayers.Add(layer);
                return string.Empty;
            }
        }

        /// <summary>
        /// Removes the specified <paramref name="layer"/> from the stack. Returns an empty string, but if not present, returns an error message.
        /// </summary>
        public string RemoveLayer(RadarLayerType layer)
        {
            if (!this.RadarLayers.Contains(layer))
            {
                return $"The '{layer.ToString()}' layer has already been removed from rendering.";
            }
            else
            {
                this.RadarLayers.Remove(layer);
                return string.Empty;
            }
        }

        /// <summary>
        /// Move the specified <paramref name="layer"/> up the stack. Returns an empty string, but if not present, returns an error message.
        /// </summary>
        public string PromoteLayer(RadarLayerType layer)
        {
            if (!this.RadarLayers.Contains(layer))
            {
                return $"The '{layer.ToString()}' layer is not listed for rendering.";
            }
            else
            {
                // We really could use a linked-list, but the amount of data here is so minimal that the optimization isn't worth it.
                int idx = this.RadarLayers.IndexOf(layer);
                if (idx != 0)
                {
                    this.RadarLayers.Remove(layer);
                    this.RadarLayers.Insert(idx - 1, layer);
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Move the specified <paramref name="layer"/> down the stack. Returns an empty string, but if not present, returns an error message.
        /// </summary>
        public string DemoteLayer(RadarLayerType layer)
        {
            if (!this.RadarLayers.Contains(layer))
            {
                return $"The '{layer.ToString()}' layer is not listed for rendering.";
            }
            else
            {
                int idx = this.RadarLayers.IndexOf(layer);
                if (idx != this.RadarLayers.Count - 1)
                {
                    this.RadarLayers.Remove(layer);
                    this.RadarLayers.Insert(idx + 1, layer);
                }

                return string.Empty;
            }
        }
    }
}
