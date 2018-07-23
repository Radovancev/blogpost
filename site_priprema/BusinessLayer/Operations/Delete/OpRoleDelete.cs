using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Delete
{
    public class OpRoleDelete : OpRoleBase
    {
        public string Uuid { get; set; }
        public override OperationResult Execute(VlogEntities entities)
        {
            AspNetRole role = entities.AspNetRoles.Where(r => r.Id == Uuid && r.AspNetUsers.Count() == 0).FirstOrDefault();
            if (role != null)
            {
                entities.AspNetRoles.Remove(role);
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "Uloga ne postoji ili sadrzi korisnike.";
                return result;
            }
        }
    }
}