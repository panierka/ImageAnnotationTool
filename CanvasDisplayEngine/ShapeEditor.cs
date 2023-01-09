using CanvasDisplayEngine.EditorTools;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class ShapeEditor
    {
        private Shape? currentlyEditedShape;

        private IShapeEditingTool? currentlyEquippedEditingTool;
        private InputEventData lastInputEvent;
        private readonly EditorActionHistory actionHistory;

        public ShapeEditor() : this(new ShapeEditorOptions()) { }

        public ShapeEditor(ShapeEditorOptions options)
        {
            lastInputEvent = InputEventData.Default;
            actionHistory = new(options.ActionHistoryCapacity);
        }
        
        public void EquipEditingTool(IShapeEditingTool tool)
        {
            ReleaseTool(lastInputEvent);
            currentlyEquippedEditingTool = tool;
        }
        
        public void AssignShape(Shape shape)
        {
            ReleaseTool(lastInputEvent);
            currentlyEditedShape = shape;
        }

        public void PressTool(InputEventData inputEvent)
        {
            if (currentlyEditedShape is null)
            {
                return;
            }

            var action = currentlyEquippedEditingTool?.PressOnCoordinate(currentlyEditedShape, inputEvent);
            actionHistory.ExecuteAndRemember(action);
            lastInputEvent = inputEvent;
        }
        
        public void MoveTool(InputEventData inputEvent)
        {
            if (currentlyEditedShape is null)
            {
                return;
            }

            var action = currentlyEquippedEditingTool?.MoveOnCoordinate(currentlyEditedShape, inputEvent);
            actionHistory.ExecuteAndRemember(action);
            lastInputEvent = inputEvent;
        }
        
        public void ReleaseTool(InputEventData inputEvent)
        {
            if (currentlyEditedShape is null)
            {
                return;
            }

            var action = currentlyEquippedEditingTool?.ReleaseOnCoordinate(currentlyEditedShape, inputEvent);
            actionHistory.ExecuteAndRemember(action);
            lastInputEvent = inputEvent;
        }
        
        public void Undo()
        {
            actionHistory.UndoLast();
        }
    }
}
