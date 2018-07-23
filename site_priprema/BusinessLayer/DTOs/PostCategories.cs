using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.DTOs
{
    public class PostCategories
    {
        public PostDto[] Posts { get; set; }

        public IPagedList<PostDto> ListaPaged { get; set; }

        public CategoryDto[] Categories { get; set; }
    }
}