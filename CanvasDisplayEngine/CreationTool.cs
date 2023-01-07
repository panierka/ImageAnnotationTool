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
            
            if (point is not { })
            {
                shape.AddPoint(new(x, y));
                return;
            }

            if (point == shape.Points.First())
            {
                shape.Closed = true;
            }       
        }

        public void MoveOnCoordinate(Shape shape, InputEventData inputEvent) { }

        public void ReleaseOnCoordinate(Shape shape, InputEventData inputEvent) { }
    }
}
