using CanvasDisplayEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor.Actions
{
    internal class ResetShapeAction : IEditorAction
    {
        private readonly Shape shape;
        private readonly List<Point> pointsSnapshot;
        private readonly bool wasClosed;

        public ResetShapeAction(Shape shape)
        {
            this.shape = shape;
            pointsSnapshot = shape.Points.ToList();
            wasClosed = shape.IsClosed;
        }

        public void Execute()
        {
            pointsSnapshot
                .ForEach(point => shape.RemovePoint(point));
        }

        public void Undo()
        {
            pointsSnapshot
                .ForEach(point => shape.AddPoint(point));
            shape.IsClosed = wasClosed;
        }
    }
}
