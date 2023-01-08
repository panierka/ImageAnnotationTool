﻿using Blazor.Extensions.Canvas.Canvas2D;
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
        
        public bool Closed { get; set; }
        
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

            // do not change order -w
            await DrawPoints(canvasContext);
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
            
            if (Closed)
            {
                await canvasContext.ClosePathAsync();
            }
        }

        private async Task FillPolygon(Canvas2DContext canvasContext)
        {
            if (!Closed)
            {
                return;
            }

            var opacity = ShapeStyleGlobalConfiguration.Instance.FillOpacity;
            var fillColor = new ColorRGBA(Color, opacity);
            await canvasContext.SetFillStyleAsync(fillColor.ToString());
            await canvasContext.FillAsync();
        }

        private async Task DrawPoints(Canvas2DContext canvasContext)
        {
            await canvasContext.SetFillStyleAsync(Color.ToString());

            foreach (var point in points)
            {
                await canvasContext.BeginPathAsync();

                var radius = ShapeStyleGlobalConfiguration.Instance.PointRadius;
                await canvasContext.ArcAsync(point.X, point.Y, radius, 0, 2 * Math.PI);
                await canvasContext.FillAsync();
                await canvasContext.ClosePathAsync();
            }
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
                Closed = false;
            }
        }
        
        public void InsertPoint(Point point, int index)
        {
            points.Insert(index, point);
        }

        public IEnumerable<Point> Points => points;
    }
}