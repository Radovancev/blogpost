using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer
{
	public class OperationManager
	{
		private static VlogEntities entities = new VlogEntities();
		#region Singleton
		private static OperationManager singleton;

		public static OperationManager Singleton
		{
			get
			{
				if (singleton == null)
				{
					singleton = new OperationManager();
				}
				return singleton;
			}
		} 

		private OperationManager() { }
		#endregion
		
		public OperationResult ExecuteOperation(Operation op)
		{
			OperationResult result;
			try
			{
				result = op.Execute(entities);
			}
			catch(Exception e)
			{
				result = new OperationResult();
				result.Message = e.Message;
				result.Status = false;
			}
			return result;
		}
	}
}