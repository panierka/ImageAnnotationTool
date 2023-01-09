using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;

namespace ShapeEditor.Actions
{
    public class PointAppendanceAction : IEditorAction
    {
        private readonly Shape shape;
        private readonly Point point;

        public PointAppendanceAction(Shape shape, Point point)
        {
            this.shape = shape;
            this.point = point;
        }

        public void Execute()
        {
            shape.AddPoint(point);
        }

        public void Undo()
        {
            shape.RemovePoint(point);
        }
    }
}
