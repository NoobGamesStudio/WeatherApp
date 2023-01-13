using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA_Utility.Service;

namespace WA_Front.Canvas
{
    internal class WindDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float padding = 10;
            canvas.StrokeColor = Color.FromRgb(0, 0, 0);
            canvas.DrawEllipse(padding, padding, dirtyRect.Width-padding, dirtyRect.Height-padding);
            canvas.DrawString("N", dirtyRect.Width / 2, padding, HorizontalAlignment.Center);
            canvas.DrawString("E", dirtyRect.Width, dirtyRect.Height / 2, HorizontalAlignment.Center);
            canvas.DrawString("S", dirtyRect.Width / 2, dirtyRect.Height, HorizontalAlignment.Center);
            canvas.DrawString("W", padding, dirtyRect.Height / 2, HorizontalAlignment.Center);
        }
    }
}
