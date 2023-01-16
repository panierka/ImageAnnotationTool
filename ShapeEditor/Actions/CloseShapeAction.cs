using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;

namespace ShapeEditing.Actions
{
    public class CloseShapeAction : IEditorAction
    {
        private readonly Shape shape;

        public CloseShapeAction(Shape shape)
        {
            this.shape = shape;
        }

        public void Execute()
        {
            shape.IsClosed = true;
        }

        public void Undo()
        {
            shape.IsClosed = false;
        }
    }
}
