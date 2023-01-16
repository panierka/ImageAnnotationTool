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
        private readonly string defaultTool;

        public ShapeToolset(string defaultTool)
        {
            this.defaultTool = defaultTool;
        }

        public void AddTool(string key, IShapeEditingTool tool)
        {
            tools.Add(key, tool);
        }
        
        public IShapeEditingTool? GetTool(string key)
        {
            return tools.GetValueOrDefault(key);
        }

        public IShapeEditingTool? GetDefaultTool()
        {
            return GetTool(defaultTool);
        }
    }
}
