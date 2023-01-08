using CanvasDisplayEngine.EditorActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine.EditorTools
{
    public class CreationTool : IShapeEditingTool
    {
        public IEditorAction? PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            if (shape.Closed)
            {
                return null;
            }

            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            var point = ShapeInterpreter.GetPointWithCoordinates(shape, x, y);

            if (point is not { })
            {
                return new PointAppendanceAction(shape, new(x, y));
            }

            if (point == shape.Points.First())
            {
                return new CloseShapeAction(shape);
            }

            return null;
        }

        public IEditorAction? MoveOnCoordinate(Shape shape, InputEventData inputEvent) => null;

        public IEditorAction? ReleaseOnCoordinate(Shape shape, InputEventData inputEvent) => null;
    }
}
