using ShapeEditor.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditor
{
    public class ShapeToolsetHandler
    {
        private readonly Dictionary<ShapeEditionType, ShapeToolset> toolsets = new();
        private ShapeToolset currentToolset = null!;

        private readonly ShapeEditor shapeEditor;

        public ShapeToolsetHandler(ShapeEditor shapeEditor)
        {
            this.shapeEditor = shapeEditor;
        }

        public void AddToolset(ShapeEditionType type, ShapeToolset toolset)
        {
            toolsets.Add(type, toolset);
            currentToolset ??= toolset;
        }

        public void EquipToolset(ShapeEditionType type)
        {
            if (toolsets.TryGetValue(type, out var toolset))
            {
                currentToolset = toolset;
                var defaultTool = currentToolset.GetDefaultTool();
                EquipTool(defaultTool);
            }
        }

        public void EquipToolFromCurrentToolset(string key)
        {
            var tool = currentToolset.GetTool(key);
            EquipTool(tool);
        }

        private void EquipTool(IShapeEditingTool? tool)
        {
            if (tool is { })
            {
                shapeEditor.EquipEditingTool(tool);
            }
        }
    }
}
