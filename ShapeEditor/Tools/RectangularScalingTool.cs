using CanvasDisplayEngine;
using ShapeEditor.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovementData = ShapeEditor.Actions.MultiPointMovementAction.MovementData;

namespace ShapeEditor.Tools
{
    public class RectangularScalingTool : IShapeEditingTool
    {
        private double startingX;
        private double startingY;
        private double lastX;
        private double lastY;

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
            
            var k = shape.Points.Count() - 1;
            var shift = (k + 1) % 2;

            var startIndex = shape
                .Points
                .TakeWhile(p => p != point)
                .Count();

            var rearanged = shape
                .Points
                .Skip(startIndex + 1)
                .Concat(shape.Points.Take(startIndex + 1));

            var validPoints = rearanged
                .Take(k / 2 - shift)
                .Concat(rearanged.TakeLast(k / 2 + 1 - shift));
            
            currentMovements = validPoints
                .Select(p => new MovementData(p, p.X, p.Y))
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
                if (Math.Abs(data.StartingX - startingX) < 5)
                {
                    data.Point.X += dx;
                }

                if (Math.Abs(data.StartingY - startingY) < 5)
                {
                    data.Point.Y += dy;
                }
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
    }
}
