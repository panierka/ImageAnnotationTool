using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;

namespace ShapeEditing.Actions
{
    public class PointInsertionAction : IEditorAction
    {
        private readonly Shape shape;
        private readonly Point point;
        private readonly int index;

        public PointInsertionAction(Shape shape, Point point, int index)
        {
            this.shape = shape;
            this.point = point;
            this.index = index;
        }

        public void Execute()
        {
            shape.InsertPoint(point, index);
        }

        public void Undo()
        {
            shape.RemovePoint(point);
        }
    }
}
