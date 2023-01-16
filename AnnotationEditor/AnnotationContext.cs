using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeEditing;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using CanvasDisplayEngine;

namespace AnnotationEditor
{
    public class AnnotationContext
    {
        private readonly ShapeEditor editor;
        private readonly Annotation annotation;
        private readonly IColorProvider colorProvider;

        public Shape Shape { get; }

        private ColorRGB color = null!;

        public AnnotationContext(ShapeEditor editor, Annotation annotation, IColorProvider colorProvider)
        {
            this.editor = editor;
            this.annotation = annotation;

            color = colorProvider.GetNextColor();
            Shape = new(color);
            this.colorProvider = colorProvider;
        }
    }
}
