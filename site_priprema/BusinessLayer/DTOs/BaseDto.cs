using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.DTOs
{
	public abstract class BaseDto
	{
		public int Id { get; set; }

		public string Uuid { get; set; }
	}
}