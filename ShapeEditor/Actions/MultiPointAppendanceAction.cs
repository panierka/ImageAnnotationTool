using CanvasDisplayEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapeEditor.Actions.MultiPointMovementAction;

namespace ShapeEditor.Actions
{
    internal class MultiPointAppendanceAction : IEditorAction
    {
        private readonly List<PointAppendanceAction> creationActions = new();

        public MultiPointAppendanceAction(Shape shape, IEnumerable<Point> points)
        {
            creationActions = points
                .Select(point => new PointAppendanceAction(
                    shape,
                    point
                 ))
                .ToList();
        }

        public void Execute()
        {
            creationActions.ForEach(x => x.Execute());
        }

        public void Undo()
        {
            creationActions.ForEach(x => x.Undo());
        }
    }
}
