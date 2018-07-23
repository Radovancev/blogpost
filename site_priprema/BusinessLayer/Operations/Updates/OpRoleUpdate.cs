using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Updates
{
    public class OpRoleUpdate : OpRoleBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            AspNetRole role = entities.AspNetRoles.Where(r => r.Id == Role.Uuid).FirstOrDefault();
            if (role != null)
            {
                role.Name = Role.Name;
                entities.SaveChanges();
                return base.Execute(entities);
            }

            OperationResult result = new OperationResult();
            result.Status = false;
            result.Message = "Uloga ne postoji.";
            return result;
        }
    }
}