using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public static class ShapeInterpreter
    {
        public static Point? GetPointWithCoordinates(Shape shape, double x, double y)
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

        public static LineData? GetLineWithCoordinates(Shape shape, double x, double y)
        {
            static double GetDistanceToLine(double x0, double y0, LineData line)
            {
                var x1 = line.StartPoint.X;
                var y1 = line.StartPoint.Y;
                var x2 = line.EndPoint.X;
                var y2 = line.EndPoint.Y;

                return Math.Abs((x2 - x1) * (y1 - y0) - (x1 - x0) * (y2 - y1))
                    / Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }

            static bool IsBetweenPoints(double x, double y, LineData line)
            {
                var x1 = (float)line.StartPoint.X;
                var y1 = (float)line.StartPoint.Y;
                var x2 = (float)line.EndPoint.X;
                var y2 = (float)line.EndPoint.Y;
                var x3 = (float)x;
                var y3 = (float)y;

                var d0 = new Vector2(x2 - x1, y2 - y1);
                var d0Norm = MathF.Sqrt(MathF.Pow(d0.X, 2) + MathF.Pow(d0.Y, 2));
                var v = d0 / d0Norm;
                
                var d1 = new Vector2(x3 - x1, y3 - y1);
                var r = Vector2.Dot(v, d1);

                return 0 <= r && r <= d0Norm;
            }

            const double EPS = 3;
            return shape
                .Points
                .Zip(shape.Points
                    .Skip(1).Concat(shape.Points.Take(1)), (a, b) => new LineData
                    {
                        StartPoint = a,
                        EndPoint = b
                    })
                .Select(line => new 
                { 
                    Line = line, 
                    Distance = GetDistanceToLine(x, y, line)
                })
                .Where(d => d.Distance <= EPS)
                .OrderBy(d => d.Distance)
                .Select(d => d.Line)
                .Where(line => IsBetweenPoints(x, y, line))
                .FirstOrDefault();
        }       
    }
}