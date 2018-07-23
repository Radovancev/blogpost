using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Inserts
{
    public class OpRoleInsert : OpRoleBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            AspNetRole role = new AspNetRole();
            role.Name = this.Role.Name;
            role.Id = Guid.NewGuid().ToString();

            entities.AspNetRoles.Add(role);
            entities.SaveChanges();
            return base.Execute(entities);
        }
    }
}