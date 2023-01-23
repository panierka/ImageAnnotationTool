using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;

namespace ShapeEditing.Actions
{
    public class PointRemovalAction : IEditorAction
    {
        private readonly Shape shape;
        private readonly Point point;
        private readonly int index;

        public PointRemovalAction(Shape shape, Point point)
        {
            this.shape = shape;
            this.point = point;
            index = shape.Points.TakeWhile(p => point != p).Count();
        }

        public void Execute()
        {
            shape.RemovePoint(point);
        }

        public void Undo()
        {
            shape.InsertPoint(point, index);
        }
    }
}
