using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonoUI.Helpers
{
    public class Drawing
    {
        public StringFormat SetPosition(StringAlignment horizontal = StringAlignment.Center, StringAlignment vertical = StringAlignment.Center)
        {
            return new StringFormat
            {
                Alignment = horizontal,
                LineAlignment = vertical
            };
        }

        public void DrawImageWithTransparency(Graphics G, float alpha, Image image, Rectangle rect)
        {
            var colorMatrix = new ColorMatrix { Matrix33 = alpha };
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix);
            G.DrawImage(image, new Rectangle(rect.X, rect.Y, image.Width, image.Height), rect.X, rect.Y, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
            imageAttributes.Dispose();
        }
    }
}
