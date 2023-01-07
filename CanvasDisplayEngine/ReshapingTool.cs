using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class ReshapingTool : IShapeEditingTool
    {
        private Point? currentlyHeldPoint;

        public void PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;
            currentlyHeldPoint = GetPointWithCoordinates(shape, x, y);
        }

        public void MoveOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;
            currentlyHeldPoint?.SetPosition(x, y);
        }

        public void ReleaseOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            currentlyHeldPoint = null;
        }

        private static Point? GetPointWithCoordinates(Shape shape, double x, double y)
        {
            static double GetDistanceToPoint(double x, double y, Point p)
            {
                var d = Math.Sqrt(Math.Pow(x - p.X, 2) + Math.Pow(y - p.Y, 2));
                return d;
            }

            const double EPS = 10;

            return shape
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
