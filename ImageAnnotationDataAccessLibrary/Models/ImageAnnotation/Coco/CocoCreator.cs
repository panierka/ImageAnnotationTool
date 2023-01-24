using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasDisplayEngine;
using ImageAnnotationToolDataAccessLibrary.Models.ExifExtraction;
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

		public static List<Image> CreateImages(List<AnnotatedImage> annotatedImages)
		{
			var images = new List<Image>();

			foreach (var annotatedImage in annotatedImages)
			{
				var image = CreateImage(annotatedImage);
				images.Add(image);
			}
			return images;
		}

		//Annotation
		public static int GetAnnotationId(AnnotatedImage annotatedImage)
		{
			return annotatedImage.Id;
		}
		public static List<double> CreateSegmentation(List<Point> points)
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
		public static double GetArea(List<Point> points)
		{
			var area = Math.Abs(points.Take(points.Count - 1)
					   .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
					   .Sum() / 2);

			return area;
		}
		public static List<double> CreateBbox(List<Point> points)
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
		public static List<Annotation> CreateAnnotationsOfImage(AnnotatedImage annotatedImage)
		{
			var annotationsOfImage = annotatedImage.Annotations;
			var annotations = new List<Annotation>();

			foreach (var annotation in annotationsOfImage)
			{
				var points = annotation.PointsX.Zip(annotation.PointsY, (x, y) => new Point(x, y)).ToList();
				var segmentation = new List<List<double>> { CreateSegmentation(points) };
				var returnAnnotation = new Annotation()
				{
					Id = annotatedImage.Id,
					CategoryId = annotation.Class.Id,
					Iscrowd = 0,
					Segmentation = segmentation,
					ImageId = GetImageId(annotatedImage),
					Area = GetArea(points),
					Bbox = CreateBbox(points)
				};
				annotations.Add(returnAnnotation);
			}
			return annotations;
		}
		public static List<Annotation> CreateAnnotations(List<AnnotatedImage> annotatedImages)
		{
			var annotations = new List<Annotation>();
			var images = annotatedImages;
			foreach (var image in images)
			{
				var imageAnnotations = CreateAnnotationsOfImage(image);

				annotations.AddRange(imageAnnotations);
			}
			return annotations;
		}

		//Category
		public static List<Category> CreateCategories(AnnotatedImage annotatedImage)
		{
			var annotationClasses = annotatedImage.Annotations;
			var categories = new List<Category>();
			foreach (var annotationClass in annotationClasses)
			{
				var category = new Category()
				{
					Supercategory = "",
					Id = annotationClass.Class.Id,
					Name = annotationClass.Class.Name
				};
				categories.Add(category);
			}
			return categories;
		}

		//Exif
		public static List<Exif> CreateExifs(List<AnnotatedImage> annotatedImages)
		{
			var exifs = new List<Exif>();
			foreach (var annotatedImage in annotatedImages)
			{
				exifs.Add(annotatedImage.ImageData.Exif);
			}
			return exifs;
		}

		//Coco
		public static void CreateCoco(Team team, List<AnnotatedImage> annotatedImages)
		{
			var coco = new Coco()
			{
				Info = CreateInfo(team),
				Images = CreateImages(annotatedImages),
				Annotations = CreateAnnotations(annotatedImages),
				Exifs = CreateExifs(annotatedImages)
			};
		}
	}
}
