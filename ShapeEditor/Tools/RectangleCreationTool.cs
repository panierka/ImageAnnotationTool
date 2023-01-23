using CanvasDisplayEngine;
using ShapeEditing.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapeEditing.Actions.MultiPointMovementAction;

namespace ShapeEditing.Tools
{
    public class RectangleCreationTool : IShapeEditingTool
    {
        private double startingX;
        private double startingY;

        private Point? point;

        public IEditorAction? PressOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            if (shape.IsClosed)
            {
                return null;
            }

            var x = inputEvent.MouseX;
            var y = inputEvent.MouseY;

            if (!shape.Points.Any())
            {
                return PutFirstPoint(shape, x, y);
            }

            return PutRemainingPoints(shape, x, y);
        }

        private IEditorAction PutRemainingPoints(Shape shape, double x, double y)
        {
            var points = new Point[]
                        {
                new Point(x, startingY),
                new Point(x, y),
                new Point(startingX, y)
                        };

            return new GroupedAction(
                new IEditorAction[]
                {
                    new MultiPointAppendanceAction(shape, points),
                    new CloseShapeAction(shape)
                }
             );
        }

        private IEditorAction PutFirstPoint(Shape shape, double x, double y)
        {
            startingX = x;
            startingY = y;

            point = new(x, y);
            return new PointAppendanceAction(shape, point);
        }

        public IEditorAction? MoveOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            return null;
        }

        public IEditorAction? ReleaseOnCoordinate(Shape shape, InputEventData inputEvent)
        {
            return null;
        }
    }
}
