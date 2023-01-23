using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco;
using ImageAnnotationToolDataAccessLibrary.Serialization;
using ImageAnnotationToolDataAccessLibrary.JsonFiles;
using NuGet.Frameworks;
using System.Linq;

namespace JsonSerializationAndDeserializationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var serialization = new JsonSerialization<Coco>();
            var deserialization = new JsonDeserialization<Coco>();


            var info = new Info
            { 
                Description = "COCO 2017 Dataset", 
                Url = "http://cocodataset.org",
                Version = "1.0",
                Year = 2017,
                Contributor = "COCO Consortium",
                DateCreated = "2017/09/01"
            };

            var license1 = new License
            {
                Id = 4,
                Name = "Attribution License",
                Url = "http://creativecommons.org/licenses/by/2.0/"
            };

            var image1 = new Image
            {
                Id = 242287,
                Width = 426,
                Height = 640,
                FileName = "xxxxxxxxx.jpg",
                License = 4,
                DateCaptured = "2013-11-15 02:41:42",
                CocoUrl = "http://images.cocodataset.org/val2017/xxxxxxxxxxxx.jpg",
                FlickrUrl = "http://farm3.staticflickr.com/2626/xxxxxxxxxxxx.jpg"
            };

            var image2 = new Image
            {
                Id = 245915,
                Width = 640,
                Height = 480,
                FileName = "nnnnnnnnnn.jpg",
                License = 4,
                DateCaptured = "2013-11-18 02:53:27",
                CocoUrl = "http://images.cocodataset.org/val2017/nnnnnnnnnnnn.jpg",
                FlickrUrl = "http://farm1.staticflickr.com/88/xxxxxxxxxxxx.jpg"
            };

            var annotation1 = new Annotation
            {
                Id = 125686,
                ImageId = 242287,
                CategoryId = 0,
                Iscrowd = 0,
                Segmentation = new List<List<double>> { new List<double> { 164.81, 417.51, 167.55, 410.64 } },
                Area = 42061.80340000001,
                Bbox = new List<double> { 19.23, 383.18, 314.5, 244.46 }
            };

            var annotation2 = new Annotation
            {
                Id = 1409619,
                ImageId = 245915,
                CategoryId = 0,
                Iscrowd = 0,
                Segmentation = new List<List<double>> { new List<double> { 376.81, 238.8, 382.74, 241.17 } },
                Area = 3556.2197000000015,
                Bbox = new List<double> { 399, 251, 155, 101 }
            };

            var annotation3 = new Annotation
            {
                Id = 1410165,
                ImageId = 245915,
                CategoryId = 1,
                Iscrowd = 0,
                Segmentation = new List<List<double>> { new List<double> { 486.34, 239.01, 495.95, 244.39 } },
                Area = 1775.8932499999994,
                Bbox = new List<double> { 86, 65, 220, 334 }
            };

            var catergory1 = new Category
            {
                Supercategory = "speaker",
                Id = 0,
                Name = "echo"
            };

            var catergory2 = new Category
            {
                Supercategory = "speaker",
                Id = 1,
                Name = "echo dot"
            };

            var coco = new Coco
            {
                Info = info,
                Licenses = new List<License> { license1 },
                Images = new List<Image> { image1, image2 },
                Annotations = new List<Annotation> { annotation1, annotation2, annotation3 },
                Categories = new List<Category> { catergory1, catergory2 }
            };

            const string predicted1 = "{\r\n    \"info\": {\r\n        \"description\": \"COCO 2017 Dataset\",\"url\": \"http://cocodataset.org\",\"version\": \"1.0\",\"year\": 2017,\"contributor\": \"COCO Consortium\",\"date_created\": \"2017/09/01\"\r\n    },\r\n    \"licenses\": [\r\n        {\"url\": \"http://creativecommons.org/licenses/by/2.0/\",\"id\": 4,\"name\": \"Attribution License\"}\r\n    ],\r\n    \"images\": [\r\n        {\"id\": 242287, \"license\": 4, \"coco_url\": \"http://images.cocodataset.org/val2017/xxxxxxxxxxxx.jpg\", \"flickr_url\": \"http://farm3.staticflickr.com/2626/xxxxxxxxxxxx.jpg\", \"width\": 426, \"height\": 640, \"file_name\": \"xxxxxxxxx.jpg\", \"date_captured\": \"2013-11-15 02:41:42\"},\r\n        {\"id\": 245915, \"license\": 4, \"coco_url\": \"http://images.cocodataset.org/val2017/nnnnnnnnnnnn.jpg\", \"flickr_url\": \"http://farm1.staticflickr.com/88/xxxxxxxxxxxx.jpg\", \"width\": 640, \"height\": 480, \"file_name\": \"nnnnnnnnnn.jpg\", \"date_captured\": \"2013-11-18 02:53:27\"}\r\n    ],\r\n    \"annotations\": [\r\n        {\"id\": 125686, \"category_id\": 0, \"iscrowd\": 0, \"segmentation\": [[164.81, 417.51,167.55, 410.64]], \"image_id\": 242287, \"area\": 42061.80340000001, \"bbox\": [19.23, 383.18, 314.5, 244.46]},\r\n        {\"id\": 1409619, \"category_id\": 0, \"iscrowd\": 0, \"segmentation\": [[376.81, 238.8,382.74, 241.17]], \"image_id\": 245915, \"area\": 3556.2197000000015, \"bbox\": [399, 251, 155, 101]},\r\n        {\"id\": 1410165, \"category_id\": 1, \"iscrowd\": 0, \"segmentation\": [[486.34, 239.01,495.95, 244.39]], \"image_id\": 245915, \"area\": 1775.8932499999994, \"bbox\": [86, 65, 220, 334]}\r\n    ],\r\n    \"categories\": [\r\n        {\"supercategory\": \"speaker\",\"id\": 0,\"name\": \"echo\"},\r\n        {\"supercategory\": \"speaker\",\"id\": 1,\"name\": \"echo dot\"}\r\n    ]\r\n}";

            string predicted2 = String.Concat(predicted1.Where(c => !Char.IsWhiteSpace(c)));

            var actual1 = serialization.Serialize(coco);

            var actual2 = String.Concat(actual1.Where(c => !Char.IsWhiteSpace(c)));

            Assert.AreEqual(predicted2, actual2);

            var predicted3 = coco;

            var actual3 = deserialization.Deserialize(predicted1);

            //Assert.AreEqual(predicted3, actual3);
        }
    }
}