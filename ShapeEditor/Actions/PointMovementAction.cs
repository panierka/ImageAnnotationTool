using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;


namespace ShapeEditor.Actions
{
    internal class PointMovementAction : IEditorAction
    {
        private readonly Point point;
        private readonly double startingX;
        private readonly double startingY;
        private readonly double targetX;
        private readonly double targetY;
        
        public PointMovementAction(Point point, double targetX, double targetY, double startingX, double startingY)
        {
            this.point = point;

            this.targetX = targetX;
            this.targetY = targetY;
            this.startingX = startingX;
            this.startingY = startingY;
        }

        public void Execute()
        {
            point.SetPosition(targetX, targetY);
        }
        
        public void Undo()
        {
            point.SetPosition(startingX, startingY);
        }
    }
}
