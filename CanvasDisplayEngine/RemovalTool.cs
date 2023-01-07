using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class RemovalTool : IShapeEditingTool
    {
        public void PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            var point = ShapeInterpreter.GetPointWithCoordinates(shape, x, y);
            
            if (point is { })
            {
                shape.RemovePoint(point);
            }
        }

        public void MoveOnCoordinate(Shape shape, InputEventData inputEvent) { }

        public void ReleaseOnCoordinate(Shape shape, InputEventData inputEvent) { }
    }
}
