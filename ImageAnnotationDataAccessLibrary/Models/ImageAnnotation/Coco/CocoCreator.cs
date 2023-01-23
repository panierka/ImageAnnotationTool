using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public class CocoCreator
    {
        public List<double> CreateSegmentation(Point[] points)
        {
            var segmenationList = new List<double>();
            foreach (var point in points)
            {
                segmenationList.Add(point.X);
                segmenationList.Add(point.Y);
            }

            return segmenationList;
        }

        public List<double> CreateBbox(Point[] points)
        {
            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);

            var width = maxX - minX;
            var height = maxY - minY;

            var returnBbox = new List<double>() { minX, maxY, width, height };

            return returnBbox;
        }
    }
}
