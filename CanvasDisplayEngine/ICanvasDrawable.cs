using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDisplayEngine
{
    public interface ICanvasDrawable
    {
        public Task DrawAsync(Canvas2DContext canvasContext);
    }
}
