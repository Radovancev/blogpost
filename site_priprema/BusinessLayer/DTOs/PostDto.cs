using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site_priprema.BusinessLayer.DTOs
{
	public class PostDto : BaseDto
	{
		public string Text { get; set; }
        public string Post { get; set; }
		public Nullable<System.DateTime> Created_At { get; set; }
		public Nullable<System.DateTime> Updated_At { get; set; }
		public int CategoryID { get; set; }
		public string UserID { get; set; }
		public string Path { get; set; }


		public string Username { get; set; }

        public List<CommentDto> Comment { get; set; }

        [AllowHtml]
        [Display(Name = "CommentText")]
        public string CommentText { get; set; }
	}
}