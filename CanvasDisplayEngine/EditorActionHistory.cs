using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine.EditorActions;

namespace CanvasDisplayEngine
{
    internal class EditorActionHistory
    {
        private readonly ForgetfulStack<IEditorAction> pastActions;

        public EditorActionHistory(int historyLimit)
        {
            pastActions = new(capacity: historyLimit);
        }

        public void ExecuteAndRemember(IEditorAction? action)
        {
            if (action is null)
            {
                return;
            }
            
            action.Execute();
            pastActions.Push(action);
        }
        
        public void UndoLast()
        {
            if (pastActions.TryPop(out var action))
            {
                action!.Undo();
            }
        }
    }
}
