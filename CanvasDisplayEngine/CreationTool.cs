using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class CreationTool : IShapeEditingTool
    {
        public void PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            if (shape.Closed)
            {
                return;
            }

            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            var point = ShapeInterpreter.GetPointWithCoordinates(shape, x, y);
            
            if (point is { })
            {
                shape.Closed = true;
                return;
            }

            shape.AddPoint(new(x, y));
        }

        public void MoveOnCoordinate(Shape shape, InputEventData inputEvent) { }

        public void ReleaseOnCoordinate(Shape shape, InputEventData inputEvent) { }
    }
}
