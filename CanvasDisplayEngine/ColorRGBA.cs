using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class ColorRGBA
    {
        public byte Red 
        { 
            get => baseColor.Red; 
            set => baseColor.Red = value; 
        }

        public byte Green
        {
            get => baseColor.Green;
            set => baseColor.Green = value;
        }

        public byte Blue
        {
            get => baseColor.Blue;
            set => baseColor.Blue = value;
        }

        public float Alpha { get; set; }

        private readonly ColorRGB baseColor;

        public ColorRGBA(ColorRGB baseColor, float alpha)
        {
            this.baseColor = baseColor;
            Alpha = alpha;
        }

        public override string ToString()
        {
            return $"rgba({Red}, {Green}, {Blue}, {Alpha})";
        }
    }
}
