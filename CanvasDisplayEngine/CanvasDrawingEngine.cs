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
        private Canvas2DContext canvasContext;
        public List<ICanvasDrawable> Drawables { get; } = new();

        public CanvasDrawingEngine(Canvas2DContext canvasContext)
        {
            this.canvasContext = canvasContext;
        }
        
        public async Task RenderFrame()
        {        
            foreach (var drawable in Drawables)
            {
                await drawable.DrawAsync(canvasContext);
            }
        }
    }
}
