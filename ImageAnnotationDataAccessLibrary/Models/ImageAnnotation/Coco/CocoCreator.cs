﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public class CocoCreator
    {
        //Info
		public static int GetYear()
		{
			return DateTime.Now.Year;
		}
		//public static string GetContributor(Team team)
		//{
		//	var contributor = team.Name;

		//	return contributor;
		//}
		public static string GetDate()
        {
            return DateTime.Now.ToString();
        }
		public static Info CreateInfo(Team team)
		{
			var info = new Info()
			{
				Description = team.Name,
				Version = "1.0",
				Year = GetYear(),
				Contributor = team.Name,
				DateCreated = GetDate()
			};
			return info;
		}

		//Image
		public static int GetImageId(AnnotatedImage annotatedImage)
		{
			return annotatedImage.ImageData.Id; ;
		}

		public static int GetWidth(AnnotatedImage annotatedImage)
		{
			return annotatedImage.ImageData.Width;
		}
		public static int GetHeight(AnnotatedImage annotatedImage)
		{
			return annotatedImage.ImageData.Height;
		}
		public static string GetFileName(AnnotatedImage annotatedImage)
		{
			string fileName = annotatedImage.ImageData.Name + annotatedImage.ImageData.Extension;
			return fileName;
		}
		public static string GetDateCaptured(AnnotatedImage annotatedImage)
		{
			return annotatedImage.ImageData.Exif.DateTime.ToString();
		}
		public static Image CreateImage(AnnotatedImage annotatedImage)
		{
			var image = new Image()
			{
				Id = GetImageId(annotatedImage),
				Width = GetWidth(annotatedImage),
				Height = GetHeight(annotatedImage),
				FileName = GetFileName(annotatedImage),
				DateCaptured = GetDateCaptured(annotatedImage)
			};
			return image;
		}

		//Annotation
		public static int GetAnnotationId(AnnotatedImage annotatedImage)
		{
			return annotatedImage.Id;
		}
		public static List<double> CreateSegmentation(Point[] points)
		{
			var segmenationList = new List<double>();
			foreach (var point in points)
			{
				segmenationList.Add(point.X);
				segmenationList.Add(point.Y);
			}
			return segmenationList;
		}
		//GetImageId
		public static double GetArea(Point[] points)
		{

			var area = Math.Abs(points.Take(points.Length - 1)
					   .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
					   .Sum() / 2);

			return area;
		}
		public static List<double> CreateBbox(Point[] points)
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
		public static Annotation CreateAnnotation(AnnotatedImage annotatedImage, Point[] points)
		{
			var segmentation = new List<List<double>> { CreateSegmentation(points) };
			var annotation = new Annotation()
			{
				Id = annotatedImage.Id,
				Iscrowd = 0,
				Segmentation = segmentation,
				ImageId = GetImageId(annotatedImage),
				Area = GetArea(points),
				Bbox = CreateBbox(points)
			};
			return annotation;
		}
	}
}
