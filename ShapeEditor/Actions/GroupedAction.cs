using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor.Actions
{
    internal class GroupedAction : IEditorAction
    {
        private readonly List<IEditorAction> actions;

        public GroupedAction(IEnumerable<IEditorAction> actions)
        {
            this.actions = actions.ToList();
        }
        
        public void Execute()
        {
            actions.ForEach(x => x.Execute());
        }

        public void Undo()
        {
            actions.ForEach(x => x.Undo());
        }
    }
}
