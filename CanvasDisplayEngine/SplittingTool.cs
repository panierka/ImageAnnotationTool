using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class SplittingTool : IShapeEditingTool
    {
        public void PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            var tryGetLineResult = ShapeInterpreter.GetLineWithCoordinates(shape, x, y);

            if (tryGetLineResult is not LineData line)
            {
                return;
            }

            var endPoint = line.EndPoint;
            var insertIndex = shape
                .Points
                .TakeWhile(point => endPoint != point)
                .Count();
            
            shape.InsertPoint(new(x, y), insertIndex);
        }

        public void MoveOnCoordinate(Shape shape, InputEventData inputEvent) { }

        public void ReleaseOnCoordinate(Shape shape, InputEventData inputEvent) { }
    }
}
