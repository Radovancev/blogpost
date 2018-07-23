using site_priprema.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace site_priprema.Models
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Post")]
        public string Post1 { get; set; }

        [Required]
        [Display(Name = "Insert your description of the post")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required]
        public int CategoryID { get; set; }
        
        [ValidateImage(ErrorMessage = "Image is not in the right resolution.")]
        public HttpPostedFileBase Path { get; set; }
    }
}