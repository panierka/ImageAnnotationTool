using System;
using System.Collections.Generic;
using CanvasDisplayEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditing.Actions
{
    internal class MultiPointMovementAction : IEditorAction
    {
        private readonly List<PointMovementAction> movementActions = new();

        public MultiPointMovementAction(IEnumerable<MovementData> movementDatas)
        {
            movementActions = movementDatas
                .Select(data => new PointMovementAction(
                    data.Point,
                    data.Point.X,
                    data.Point.Y,
                    data.StartingX,
                    data.StartingY
                 ))
                .ToList();
        }

        public void Execute()
        {
            movementActions.ForEach(x => x.Execute());
        }
        
        public void Undo()
        {
            movementActions.ForEach(x => x.Undo());
        }
        
        public record MovementData
        {
            public Point Point { get; set; } 
            public double StartingX { get; set; }
            public double StartingY { get; set; }

            public MovementData(Point point, double startingX, double startingY)
            {
                Point = point;
                StartingX = startingX;
                StartingY = startingY;
            }
        }
    }
}
