using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class ShapeStyle
    {
        private static ShapeStyle? instance;
        public static ShapeStyle Instance => instance ??= new();

        public float LineWidth { get; set; } = 2;
        public double PointRadius { get; set; } = 4;
        public double FillOpacity { get; set; } = 0.2f;
        
        private ShapeStyle() { }
    }
}
