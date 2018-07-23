using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site_priprema.BusinessLayer.DTOs
{
    public class CommentDto : BaseDto
    {
        [AllowHtml]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public Nullable<System.DateTime> Created_At { get; set; }
        public Nullable<System.DateTime> Updated_At { get; set; }
        public string UserID { get; set; }
        public int PostID { get; set; }

        public UserDto AspNetUser { get; set; }
    }
}