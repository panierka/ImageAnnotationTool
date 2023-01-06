using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public class CanvasDrawingEngine
    {
        private readonly Canvas2DContext canvasContext;
        private readonly BECanvasComponent canvas;

        public List<ICanvasDrawable> Drawables { get; } = new();

        public CanvasDrawingEngine(Canvas2DContext canvasContext, BECanvasComponent canvas)
        {
            this.canvasContext = canvasContext;
            this.canvas = canvas;
        }
        
        public async Task RenderFrame()
        {
            var sizeX = canvas.Width;
            var sizeY = canvas.Height;

            await canvasContext.BeginBatchAsync();
            await canvasContext.ClearRectAsync(0, 0, sizeX, sizeY);

            foreach (var drawable in Drawables)
            {
                await drawable.DrawAsync(canvasContext);
            }

            await canvasContext.EndBatchAsync();
        }
    }
}
