using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor.Actions
{
    public interface IEditorAction
    {
        public void Execute();

        public void Undo();
    }
}
