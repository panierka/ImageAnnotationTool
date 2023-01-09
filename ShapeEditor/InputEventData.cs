using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor
{
    public record InputEventData(double MouseX, double MouseY, long MouseButton)
    {
        public static InputEventData Default => new(0, 0, 0);
    }
}
