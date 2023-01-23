using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using MetadataExtractor;
using System.IO;
using MetadataExtractor.Formats.Exif;

namespace ImageAnnotationToolDataAccessLibrary.Models.ExifExtraction
{
    public static class ExifFromImageExtractor
    {
        public static Exif ExifFromImage(Image image)//PropertyItem[]
        {
            //PropertyItem[] propertyItems = image.PropertyItems;

            //int jd = BitConverter.ToInt32(propertyItems[0x0100].Value);

            //var exif = new Exif
            //{
            //    DateTime = propertyItems[0x0132].Value,
            //    Width = propertyItems[0x0100].Value,
            //    Height = propertyItems[0x0101].Value,
            //    ColorSpace = propertyItems[0xA001].Value,
            //    Manufacturer = propertyItems[0x010F].Value,
            //    Model = propertyItems[0x0110].Value,
            //    Aperture = propertyItems[0x9202].Value,
            //    ExposureTime = propertyItems[0x829A].Value,
            //    FocalLenght = propertyItems[0x920A].Value,
            //    Flash = propertyItems[0x9209].Value,
            //    Brightness = propertyItems[0x9203].Value,
            //    Latitude = propertyItems[0x0002].Value,
            //    Longitude = propertyItems[0x0004].Value
            //};

            var exif = new Exif { };

            return exif;

            //return propertyItems;
        }

        public static Exif ExifFromStream(MemoryStream ms)
        {
            var directories = ImageMetadataReader.ReadMetadata(ms);
            var directory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();

            var exif = new Exif { };
            
            string? returnExifVersion;
            DateTime? returnDateTime = null;
            string? returnWidth;
            string? returnHeight;
            string? returnColorSpace;
            string? returnManufacturer;
            string? returnModel;
            string? returnAperture;
            string? returnExposureTime;
            string? returnFocalLength;
            string? returnFlash;
            string? returnDigitalZoom;
            string? returnBrightness;
            string? returnLatitudeRef;
            string? returnLatitude;
            string? returnLongitudeRef;
            string? returnLongitude;

            if (directory != null)
            {
                //if (directory.TryGetDouble(ExifDirectoryBase.TagExifVersion, out var exifVersion))
                //    returnExifVersion = exifVersion;

                if (directory.TryGetDateTime(ExifDirectoryBase.TagDateTime, out var dateTime))
                    returnDateTime = dateTime;

                returnExifVersion = directory.GetString(ExifDirectoryBase.TagExifVersion);
                returnWidth = directory.GetString(ExifDirectoryBase.TagImageWidth);
                returnHeight = directory.GetString(ExifDirectoryBase.TagImageHeight);
                returnColorSpace = directory.GetString(ExifDirectoryBase.TagColorSpace);
                returnManufacturer = directory.GetString(ExifDirectoryBase.TagMake);
                returnModel = directory.GetString(ExifDirectoryBase.TagModel);
                returnAperture = directory.GetString(ExifDirectoryBase.TagAperture);
                returnExposureTime = directory.GetString(ExifDirectoryBase.TagExposureTime);
                returnFocalLength = directory.GetString(ExifDirectoryBase.TagFocalLength);
                returnFlash = directory.GetString(ExifDirectoryBase.TagFlash);
                returnDigitalZoom = directory.GetString(ExifDirectoryBase.TagDigitalZoomRatio);
                returnBrightness = directory.GetString(ExifDirectoryBase.TagBrightnessValue);
                returnLatitudeRef = directory.GetString(GpsDirectory.TagLatitudeRef);
                returnLatitude = directory.GetString(GpsDirectory.TagLatitude);
                returnLongitudeRef = directory.GetString(GpsDirectory.TagLongitudeRef);
                returnLongitude = directory.GetString(GpsDirectory.TagLongitude);

                exif = new Exif
                {
                    ExifVersion= returnExifVersion,
                    DateTime = returnDateTime,
                    Width = returnWidth,
                    Height = returnHeight,
                    ColorSpace = returnColorSpace,
                    Manufacturer = returnManufacturer,
                    Model = returnModel,
                    Aperture = returnAperture,
                    ExposureTime = returnExposureTime,
                    FocalLenght = returnFocalLength,
                    Flash = returnFlash,
                    DigitalZoom = returnDigitalZoom,
                    Brightness = returnBrightness,
                    LatitudeRef = returnLatitudeRef,
                    Latitude = returnLatitude,
                    LongitudeRef = returnLongitudeRef,
                    Longitude = returnLongitude
                };
                return exif;
            }
            else
            {
                return exif;
            }

            //var exif = new Exif
            //{
            //    DateTime = returnDateTime,
            //    //Width = propertyItems[0x0100].Value,
            //    //Height = propertyItems[0x0101].Value,
            //    ColorSpace = returnColorSpace,
            //    Manufacturer = returnManufacturer,
            //    Model = returnModel,
            //    Aperture = returnAperture,
            //    ExposureTime = returnExposureTime,
            //    FocalLenght = returnFocalLength,
            //    Flash = returnFlash,
            //    Brightness = returnBrightness,
            //    LatitudeRef = returnLatitudeRef,
            //    Latitude = returnLatitude,
            //    LongitudeRef = returnLongitudeRef,
            //    Longitude = returnLongitude
            //};

            //return exif;
        }
    }

}
