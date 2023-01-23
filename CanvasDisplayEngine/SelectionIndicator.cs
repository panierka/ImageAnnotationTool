using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class SelectionIndicator : ICanvasDrawable
    {
        public Shape? Shape { get; set; }

        public async Task DrawAsync(Canvas2DContext canvasContext)
        {
            if (Shape is null || !Shape.Points.Any())
            {
                return;
            }

            await DrawPoints(canvasContext);
        }
        
        private async Task DrawPoints(Canvas2DContext canvasContext)
        {
            await canvasContext.SetFillStyleAsync(Shape!.Color.ToString());

            foreach (var point in Shape.Points)
            {
                await canvasContext.BeginPathAsync();

                var radius = ShapeStyleGlobalConfiguration.Instance.PointRadius;
                await canvasContext.ArcAsync(point.X, point.Y, radius, 0, 2 * Math.PI);
                await canvasContext.FillAsync();
                await canvasContext.ClosePathAsync();
            }
        }
    }
}
