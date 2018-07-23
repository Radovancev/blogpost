using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Updates
{
    public class OpMenuUpdate : OpMenuBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            Menu menus = entities.Menus.Where(r => r.MenuID == Menu.Id).FirstOrDefault();
            if (menus != null)
            {
                menus.Menu1 = this.Menu.Menu;
                menus.Link = this.Menu.Link;
                menus.Area = this.Menu.Area;
                menus.Controller = this.Menu.Controller;
                menus.ParentID = this.Menu.ParentID;

                entities.SaveChanges();
                return base.Execute(entities);
            }

            OperationResult result = new OperationResult();
            result.Status = false;
            result.Message = "Meni ne postoji.";
            return result;
        }
    }
}