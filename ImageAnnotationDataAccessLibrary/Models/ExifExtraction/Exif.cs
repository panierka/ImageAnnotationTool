using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ExifExtraction
{
    public class Exif
    {
        public string? ExifVersion { get; set; }

        public DateTime? DateTime { get; set; } //0x0132 | DateTime

        public string? Width { get; set; } //0x0100 | ImageWidth

        public string? Height { get; set; } //0x0101 | ImageHeight

        public string? ColorSpace { get; set; } //0xA001 | ExifColorSpace

        public string? Manufacturer { get; set; } //0x010F | EquipMake

        public string? Model { get; set; } //0x0110 | EquipModel

        public string? Aperture { get; set; } //presłona 0x9202 | ExifAperture

        public string? ExposureTime { get; set; } //0x829A | ExifExposureTime

        public string? FocalLenght { get; set; } //ogniskowa 0x920A | ExifFocalLength

        public string? Flash { get; set; } //0x9209 | ExifFlash

        public string? DigitalZoom { get; set; } //DigitalZoomRatio???

        public string? Brightness { get; set; } //0x9203 | ExifBrightness

        public string? LatitudeRef { get; set; }

        public string? Latitude { get; set; } //szerokość geograficzna 0x0002 | GpsLatitude

        public string? LongitudeRef { get; set; }

        public string? Longitude { get; set; } //długość geograficzna 0x0004 | GpsLongitude
    }
}
