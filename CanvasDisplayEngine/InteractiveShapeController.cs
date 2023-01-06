using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class InteractiveShapeController
    {
        public Shape Shape { get; }
        private Point? currentlyHeldPoint;

        public InteractiveShapeController(Shape shape)
        {
            Shape = shape;
        }

        public void GrabPoint(MouseEventData mouseData)
        {
            var x = mouseData.X;
            var y = mouseData.Y;
            currentlyHeldPoint = GetPointWithCoordinates(x, y);
        }

        public void DragPoint(MouseEventData mouseData)
        {
            var x = mouseData.X;
            var y = mouseData.Y;
            currentlyHeldPoint?.SetPosition(x, y);
        }

        public void DropPoint(MouseEventData _)
        {
            currentlyHeldPoint = null;
        }

        private Point? GetPointWithCoordinates(double x, double y)
        {
            static double GetDistanceToPoint(double x, double y, Point p)
            {
                var d = Math.Sqrt(Math.Pow(x - p.X, 2) + Math.Pow(y - p.Y, 2));
                return d;
            }

            const double EPS = 10;

            return Shape
                .Points
                .Select(p => new
                {
                    Point = p,
                    Distance = GetDistanceToPoint(x, y, p)
                })
                .Where(d => d.Distance <= EPS)
                .OrderBy(d => d.Distance)
                .Select(d => d.Point)
                .FirstOrDefault();
        }
    }
}
