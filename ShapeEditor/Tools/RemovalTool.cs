using ShapeEditor.Actions;
using CanvasDisplayEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor.Tools
{
    public class RemovalTool : IShapeEditingTool
    {
        public IEditorAction? PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            var point = ShapeInterpreter.GetPointWithCoordinates(shape, x, y);

            if (point is { })
            {
                return new PointRemovalAction(shape, point);
            }

            return null;
        }

        public IEditorAction? MoveOnCoordinate(Shape shape, InputEventData inputEvent) => null;

        public IEditorAction? ReleaseOnCoordinate(Shape shape, InputEventData inputEvent) => null;
    }
}
