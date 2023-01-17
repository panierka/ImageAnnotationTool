using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class ColorRGB
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public ColorRGB(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return $"rgb({R}, {G}, {B})";
        }

        public static ColorRGB Red => new(255, 0, 0);
        public static ColorRGB Green => new(0, 255, 0);
        public static ColorRGB Blue => new(0, 0, 255);
        public static ColorRGB Magenta => new(255, 0, 255);
        public static ColorRGB Yellow => new(255, 255, 0);
        public static ColorRGB Cyan => new(0, 255, 255);
    }
}
