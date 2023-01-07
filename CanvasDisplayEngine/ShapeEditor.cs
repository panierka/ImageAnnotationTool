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
        public Shape Shape { get; }

        private IShapeEditingTool? currentlyEquippedEditingTool;

        public ShapeEditor(Shape shape)
        {
            Shape = shape;
        }
        
        public void EquipEditingTool(IShapeEditingTool tool)
        {
            currentlyEquippedEditingTool = tool;
        }
        
        public void CallPressOnCoordinate(InputEventData inputEvent)
        {
            currentlyEquippedEditingTool?.PressOnCoordinate(Shape, inputEvent);
        }
        
        public void CallMoveOnCoordinate(InputEventData inputEvent)
        {
            currentlyEquippedEditingTool?.MoveOnCoordinate(Shape, inputEvent);
        }
        
        public void CallReleaseOnCoordinate(InputEventData inputEvent)
        {
            currentlyEquippedEditingTool?.ReleaseOnCoordinate(Shape, inputEvent);
        }
    }
}
