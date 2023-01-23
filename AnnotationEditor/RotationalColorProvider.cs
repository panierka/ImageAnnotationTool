using CanvasDisplayEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationEditor
{
    public class RotationalColorProvider : IColorProvider
    {
        private readonly List<ColorRGB> colors;

        public RotationalColorProvider(List<ColorRGB> colors)
        {
            this.colors = colors;
        }

        private int CurrentIndex
        {
            get => currentIndex;
            set => currentIndex = value % colors.Count;
        }

        private int currentIndex;
        
        public ColorRGB GetNextColor()
        {
            var color = colors[CurrentIndex];
            CurrentIndex++;

            return color;
        }
    }
}
