using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Delete
{
    public class OpMenuDelete : OpMenuBase
    {
        public int Id { get; set; }
        public override OperationResult Execute(VlogEntities entities)
        {
            Menu menu = entities.Menus.Where(r => r.MenuID == Id).FirstOrDefault();
            if (menu != null)
            {
                entities.Menus.Remove(menu);
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "Meni ne postoji.";
                return result;
            }
        }
    }
}