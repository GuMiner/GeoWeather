using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GeoWeather
{
    /// <summary>
    /// Defines utility methods for interfacing with images.
    /// </summary>
    public static class ImageUtils
    {
        /// <summary>
        /// Overlays multiple images together in the order provided.
        /// </summary>
        /// <remarks>
        /// Images are overlaid from (0, 0). The resulting image </remarks>
        /// <param name="images">The images to overlay.</param>
        /// <returns>
        /// The overlaid image.
        /// The image size will be the maximum width and height of all the input images.
        /// If no input images are provided, a 128x128 image will be returned with a blue oval in the middle.
        /// </returns>
        public static Image OverlayImages(IEnumerable<Image> images)
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
    }
}
