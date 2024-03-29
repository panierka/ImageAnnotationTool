﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public record Image
    {
        public int Id { get; set; }

        //public int License { get; set; }

        public string? CocoUrl { get; set; }

        public string? FlickrUrl { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string FileName { get; set; }

        public string DateCaptured { get; set; }
    }
}
