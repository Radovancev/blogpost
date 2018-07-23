using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer
{
	public abstract class Operation
	{
		public abstract OperationResult Execute(VlogEntities entities);
	}
}