using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public interface IShapeEditingTool
    {
        public void PressOnCoordinate(Shape shape, InputEventData inputEvent);
        public void MoveOnCoordinate(Shape shape, InputEventData inputEvent);
        public void ReleaseOnCoordinate(Shape shape, InputEventData inputEvent);
    }
}
