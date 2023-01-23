using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeEditing;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using CanvasDisplayEngine;
using ShapeEditing.Tools;

namespace AnnotationEditor
{
    public class AnnotationContext
    {
        private readonly Annotation annotation;

        public ShapeEditor ShapeEditor { get; }
        public ShapeToolsetHandler ToolsetHandler { get; }

        public Shape Shape { get; }

        private ColorRGB color = null!;

        public Annotation Annotation => annotation;

        public ShapeEditionType Mode { get; set; } = ShapeEditionType.Rectangle;

        public AnnotationContext(Annotation annotation, IColorProvider colorProvider)
        {
            this.annotation = annotation;

            color = colorProvider.GetNextColor();
            Shape = new(color);

            ShapeEditor = new();
            ShapeEditor.AssignShape(Shape);

            ToolsetHandler = new(ShapeEditor);

            var rectangleToolset = new ShapeToolset(defaultTool: "create");
            rectangleToolset.AddTool("create", new RectangleCreationTool());
            rectangleToolset.AddTool("reshape", new RectangularScalingTool());
            rectangleToolset.AddTool("move", new MovementTool());
            ToolsetHandler.AddToolset(ShapeEditionType.Rectangle, rectangleToolset);

            var polygonToolset = new ShapeToolset(defaultTool: "create");
            polygonToolset.AddTool("create", new CreationTool());
            polygonToolset.AddTool("reshape", new ReshapingTool());
            polygonToolset.AddTool("split", new SplittingTool());
            polygonToolset.AddTool("remove", new RemovalTool());
            polygonToolset.AddTool("move", new MovementTool());
            ToolsetHandler.AddToolset(ShapeEditionType.Polygon, polygonToolset);

            ToolsetHandler.EquipToolFromCurrentToolset("create");
        }

        public void ChangeColor(ColorRGB color)
        {
            this.color = color;
            Shape.Color = color;
        }
    }
}
