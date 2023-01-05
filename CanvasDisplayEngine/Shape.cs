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
        private string Color { get; set; }
        
        public Shape(string color)
        {
            Color = color;
        }

        public async Task DrawAsync(Canvas2DContext canvasContext)
        {
            if (points.Count == 0)
            {
                return;
            }

            await canvasContext.BeginBatchAsync();
            await canvasContext.BeginPathAsync();
            await canvasContext.SetStrokeStyleAsync(Color);
            
            var previousPoint = points.First();

            foreach(var currentPoint in points.Skip(1))
            {
                await canvasContext.MoveToAsync(
                    previousPoint.X, 
                    previousPoint.Y
                );
                
                await canvasContext.LineToAsync(
                    currentPoint.X, 
                    currentPoint.Y
                );

                previousPoint = currentPoint;
            }

            await canvasContext.StrokeAsync();
            await canvasContext.EndBatchAsync();
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