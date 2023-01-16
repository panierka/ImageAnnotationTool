using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditing
{
    public record ShapeEditorOptions
    {
        public int ActionHistoryCapacity { get; set; } = 16;
    }
}
