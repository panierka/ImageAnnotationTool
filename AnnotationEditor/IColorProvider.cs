using CanvasDisplayEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationEditor
{
    public interface IColorProvider
    {
        public ColorRGB GetNextColor();
    }
}
