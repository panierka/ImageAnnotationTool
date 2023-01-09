using CanvasDisplayEngine.EditorTools;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CanvasDisplayEngine
{
    public class ShapeEditor
    {
        public Shape Shape { get; }

        private IShapeEditingTool? currentlyEquippedEditingTool;
        private InputEventData lastInputEvent;
        private readonly EditorActionHistory actionHistory;

        public ShapeEditor(Shape shape) : this(shape, new ShapeEditorOptions()) { }

        public ShapeEditor(Shape shape, ShapeEditorOptions options)
        {
            Shape = shape;
            lastInputEvent = InputEventData.Default;

            actionHistory = new(options.ActionHistoryCapacity);
        }
        
        public void EquipEditingTool(IShapeEditingTool tool)
        {
            ReleaseTool(lastInputEvent);
            currentlyEquippedEditingTool = tool;
        }
        
        public void PressTool(InputEventData inputEvent)
        {
            var action = currentlyEquippedEditingTool?.PressOnCoordinate(Shape, inputEvent);
            actionHistory.ExecuteAndRemember(action);
            lastInputEvent = inputEvent;
        }
        
        public void MoveTool(InputEventData inputEvent)
        {
            var action = currentlyEquippedEditingTool?.MoveOnCoordinate(Shape, inputEvent);
            actionHistory.ExecuteAndRemember(action);
            lastInputEvent = inputEvent;
        }
        
        public void ReleaseTool(InputEventData inputEvent)
        {
            var action = currentlyEquippedEditingTool?.ReleaseOnCoordinate(Shape, inputEvent);
            actionHistory.ExecuteAndRemember(action);
            lastInputEvent = inputEvent;
        }
        
        public void Undo()
        {
            actionHistory.UndoLast();
        }
    }
}
