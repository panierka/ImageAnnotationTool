using ShapeEditor.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor
{
    public class ShapeToolset
    {
        private readonly Dictionary<string, IShapeEditingTool> tools = new();

        public void AddTool(string key, IShapeEditingTool tool)
        {
            tools.Add(key, tool);
        }
        
        public IShapeEditingTool? GetTool(string key)
        {
            return tools.GetValueOrDefault(key);
        }
    }
}
