using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Inserts
{
    public class OpInsertMenu : OpMenuBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            Menu menu = new Menu();
            menu.Link = this.Menu.Link;
            menu.Menu1 = this.Menu.Menu;
            menu.Area = this.Menu.Area;
            menu.Controller = this.Menu.Controller;
            menu.ParentID = this.Menu.ParentID;

            entities.Menus.Add(menu);
            entities.SaveChanges();
            return base.Execute(entities);
        }
    }
}