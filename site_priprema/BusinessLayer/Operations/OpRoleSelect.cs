using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{
    public class OpRoleSelect : OpRoleBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            if (this.Criteria.Uuid != "")
            {
                IEnumerable<RoleDto> ieRoles = from roles in entities.AspNetRoles
                                               where roles.Id == this.Role.Uuid
                                               select new RoleDto
                                               {
                                                   Uuid = roles.Id,
                                                   Name = roles.Name
                                               };

                OperationResult result = new OperationResult();
                result.Items = ieRoles.ToArray();
                result.Status = true;
                return result;
            }
            return base.Execute(entities);
        }
    }
}