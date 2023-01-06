using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class Shape : ICanvasDrawable
    {
        private readonly List<Point> points = new();
        public ColorRGB Color { get; set; }
        
        public Shape(ColorRGB color)
        {
            Color = color;
        }

        public async Task DrawAsync(Canvas2DContext canvasContext)
        {
            if (points.Count == 0)
            {
                return;
            }

            await canvasContext.BeginPathAsync();
            await canvasContext.SetStrokeStyleAsync(Color.ToString());
            
            var firstPoint = points.First();
            await canvasContext.MoveToAsync(
                firstPoint.X,
                firstPoint.Y
            );

            foreach (var currentPoint in points.Skip(1).Concat(points.Take(1)))
            {      
                await canvasContext.LineToAsync(
                    currentPoint.X, 
                    currentPoint.Y
                );
            }
            
            await canvasContext.ClosePathAsync();
            await canvasContext.SetFillStyleAsync("rgba(255, 0, 0, 0.2)");
            await canvasContext.FillAsync();
            await canvasContext.StrokeAsync();
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public void RemovePoint(Point point)
        {
            points.Remove(point);
        }
    }
}