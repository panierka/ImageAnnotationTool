using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class ShapeStyleGlobalConfiguration
    {
        private static ShapeStyleGlobalConfiguration? instance;
        public static ShapeStyleGlobalConfiguration Instance => instance ??= new();

        public float LineWidth { get; set; } = 2;
        public double PointRadius { get; set; } = 4;
        public double FillOpacity { get; set; } = 0.2f;
        
        private ShapeStyleGlobalConfiguration() { }
    }
}
