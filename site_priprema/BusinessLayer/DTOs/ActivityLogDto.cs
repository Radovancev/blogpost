using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.DTOs
{
    public class ActivityLogDto : BaseDto
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IP { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}