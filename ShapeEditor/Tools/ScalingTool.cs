using CanvasDisplayEngine;
using ShapeEditing.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static ShapeEditing.Actions.MultiPointMovementAction;

namespace ShapeEditing.Tools
{
    [Obsolete("This tool does not work properly", true)]
    public class ScalingTool : IShapeEditingTool
    {
        private double startingX;
        private double startingY;
        private double lastX;
        private double lastY;
        private double centroidX;
        private double centroidY;

        private List<MovementData>? currentMovements;

        private bool ThereArePointsToMove => currentMovements is { } && currentMovements.Any();

        public IEditorAction? PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;
            var point = ShapeInterpreter.GetPointWithCoordinates(shape, x, y);

            if (point is null)
            {
                return null;
            }

            startingX = point.X;
            startingY = point.Y;

            lastX = point.X;
            lastY = point.Y;

            double n = shape.Points.Count();
            centroidX = shape.Points.Sum(p => p.X) / n;
            centroidX = shape.Points.Sum(p => p.Y) / n;

            currentMovements = shape
                .Points
                .Select(p => new MovementData(p, startingX, startingY))
                .ToList();

            return null;
        }

        public IEditorAction? MoveOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            if (!ThereArePointsToMove)
            {
                return null;
            }

            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            var dx = x - lastX;
            var dy = y - lastY;

            lastX = x;
            lastY = y;

            currentMovements!.ForEach(data =>
            {
                MovePointFromCenter(data.Point, x, y, dx, dy);
            });
            return null;
        }

        public IEditorAction? ReleaseOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            if (!ThereArePointsToMove)
            {
                return null;
            }

            var action = new MultiPointMovementAction(currentMovements!);
            currentMovements = null;
            return action;
        }

        private static double Distance(double x1, double y1,
            double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        private void MovePointFromCenter(Point point, 
            double cursorX, double cursorY, double dx, double dy)
        {
            var magnitude = Distance(point.X, point.Y, centroidX, centroidY);
            var x = (float)(point.X - centroidX);
            var y = (float)(point.Y - centroidY);

            var direction = new Vector2(x, y) / (float)magnitude;
            var delta = Distance(startingX, startingY, cursorX, cursorY);
            var scale = Distance(cursorX - startingX, cursorY - startingY, dx, dy);
            
            point.X += direction.X * delta * scale;
            point.Y += direction.Y * delta * scale;
        }
    }
}
