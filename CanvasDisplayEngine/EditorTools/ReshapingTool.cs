using CanvasDisplayEngine.EditorActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine.EditorTools
{
    public class ReshapingTool : IShapeEditingTool
    {
        private Point? currentlyHeldPoint;
        private double startingX;
        private double startingY;

        public IEditorAction? PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;
            currentlyHeldPoint = ShapeInterpreter.GetPointWithCoordinates(shape, x, y);
            
            if (currentlyHeldPoint is { })
            {
                startingX = currentlyHeldPoint.X;
                startingY = currentlyHeldPoint.Y;
            }
            
            return null;
        }

        public IEditorAction? MoveOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            if (currentlyHeldPoint is null)
            {
                return null;
            }

            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            currentlyHeldPoint.SetPosition(x, y);
            return null;
        }

        public IEditorAction? ReleaseOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            if (currentlyHeldPoint is null)
            {
                return null;
            }

            var action = new PointMovementAction(
                currentlyHeldPoint,
                currentlyHeldPoint.X, currentlyHeldPoint.Y,
                startingX, startingY);

            currentlyHeldPoint = null;
            return action;
        }
    }
}
