using ShapeEditor.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;

namespace ShapeEditor.Tools
{
    public interface IShapeEditingTool
    {
        public IEditorAction? PressOnCoordinate(Shape shape, InputEventData inputEvent);
        public IEditorAction? MoveOnCoordinate(Shape shape, InputEventData inputEvent);
        public IEditorAction? ReleaseOnCoordinate(Shape shape, InputEventData inputEvent);
    }
}
