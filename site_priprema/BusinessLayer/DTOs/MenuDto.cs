using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.DTOs
{
    public class MenuDto : BaseDto
    {
        public string Menu { get; set; }
        public string Link { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
    }
}