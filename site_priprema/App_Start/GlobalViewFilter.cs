using site_priprema.BusinessLayer;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.BusinessLayer.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site_priprema.App_Start
{
    public class GlobalViewFilter : ActionFilterAttribute
    {
        OperationManager _manager = OperationManager.Singleton;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            OpMenuBase op = new OpMenuBase();
            OperationResult links = _manager.ExecuteOperation(op);
            filterContext.Controller.ViewBag.Navigation = (links.Items as MenuDto[]).ToList();

        }
    }
}