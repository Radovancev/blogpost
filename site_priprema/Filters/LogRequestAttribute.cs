using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace site_priprema.Filters
{
    public class LogRequestAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Do some logic: Get some parameters and create log entry
            using (VlogEntities storeDb = new VlogEntities())
            {
                ActionLog log = new ActionLog()
                {
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Action = string.Concat(filterContext.ActionDescriptor.ActionName, " (Logged By: " + HttpContext.Current.User.Identity.Name + ")"),
                    IP = filterContext.HttpContext.Request.UserHostAddress,
                    DateTime = filterContext.HttpContext.Timestamp
                };
                storeDb.ActionLogs.Add(log);
                storeDb.SaveChanges();
                OnActionExecuting(filterContext);
            }

        }
    }
}