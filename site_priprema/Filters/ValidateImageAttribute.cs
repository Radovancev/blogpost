using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace site_priprema.Filters
{
    public class ValidateImageAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if(file == null)
            {
                return false;
            }
            if(file.ContentLength > 1 * 1024 * 1024)
            {
                return false;
            }
            

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Png) || img.RawFormat.Equals(ImageFormat.Jpeg) || img.RawFormat.Equals(ImageFormat.Icon) || img.RawFormat.Equals(ImageFormat.Gif) || img.RawFormat.Equals(ImageFormat.Bmp);
                }
            }
            catch
            {

            }
            return false;
        }
    }
}