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
            currentlyHeldPoint = ShapeInterpreter.GetPointWithCoordinates(shape, x, y);
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
    }
}
