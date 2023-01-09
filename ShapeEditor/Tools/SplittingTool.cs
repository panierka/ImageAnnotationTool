using ShapeEditor.Actions;
using CanvasDisplayEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor.Tools
{
    public class SplittingTool : IShapeEditingTool
    {
        public IEditorAction? PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            var tryGetLineResult = ShapeInterpreter.GetLineWithCoordinates(shape, x, y);

            if (tryGetLineResult is not LineData line)
            {
                return null;
            }

            var endPoint = line.EndPoint;
            var insertIndex = shape
                .Points
                .TakeWhile(point => endPoint != point)
                .Count();
            
            return new PointInsertionAction(shape, new(x, y), insertIndex);
        }

        public IEditorAction? MoveOnCoordinate(Shape shape, InputEventData inputEvent) => null;

        public IEditorAction? ReleaseOnCoordinate(Shape shape, InputEventData inputEvent) => null;
    }
}
