using site_priprema.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer
{
	public class OperationResult
	{
		public bool Status { get; set; }

		public string Message { get; set; }

		public BaseDto[] Items { get; set; }
	}
}