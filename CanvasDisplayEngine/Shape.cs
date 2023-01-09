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
        
        public bool IsClosed { get; set; }
        
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

            await DrawPolygon(canvasContext);
            await FillPolygon(canvasContext);

            await canvasContext.StrokeAsync();
        }
        
        private async Task DrawPolygon(Canvas2DContext canvasContext)
        {
            var lineWidth = ShapeStyleGlobalConfiguration.Instance.LineWidth;
            await canvasContext.SetLineWidthAsync(lineWidth);
            await canvasContext.SetStrokeStyleAsync(Color.ToString());
            await canvasContext.BeginPathAsync();

            var firstPoint = points.First();
            await canvasContext.MoveToAsync(
                firstPoint.X,
                firstPoint.Y
            );

            foreach (var currentPoint in points.Skip(1))
            {
                await canvasContext.LineToAsync(
                    currentPoint.X,
                    currentPoint.Y
                );
            }
            
            if (IsClosed)
            {
                await canvasContext.ClosePathAsync();
            }
        }

        private async Task FillPolygon(Canvas2DContext canvasContext)
        {
            if (!IsClosed)
            {
                return;
            }

            var opacity = ShapeStyleGlobalConfiguration.Instance.FillOpacity;
            var fillColor = new ColorRGBA(Color, opacity);
            await canvasContext.SetFillStyleAsync(fillColor.ToString());
            await canvasContext.FillAsync();
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public void RemovePoint(Point point)
        {
            points.Remove(point);

            if (points.Count <= 2)
            {
                IsClosed = false;
            }
        }
        
        public void InsertPoint(Point point, int index)
        {
            points.Insert(index, point);
        }

        public IEnumerable<Point> Points => points;
    }
}