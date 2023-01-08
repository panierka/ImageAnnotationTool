using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine.EditorActions
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
            shape.Closed = true;
        }

        public void Undo()
        {
            shape.Closed = false;
        }
    }
}
