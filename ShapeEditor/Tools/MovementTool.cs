using CanvasDisplayEngine;
using ShapeEditor.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapeEditor.Actions.MultiPointMovementAction;

namespace ShapeEditor.Tools
{
    public class MovementTool : IShapeEditingTool
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


            currentMovements = shape
                .Points
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
                data.Point.X += dx;
                data.Point.Y += dy;
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
