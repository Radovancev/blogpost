using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using site_priprema.BusinessLayer.Criterias;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{

    public class OpRoleBase : Operation
    {
        public RoleDto Role = new RoleDto();
        public RoleCriteria Criteria = new RoleCriteria();

        public override OperationResult Execute(VlogEntities entities)
        {
            IEnumerable<AspNetRole> ieRoles = entities.AspNetRoles;


            if (!Criteria.Uuid.IsNullOrWhiteSpace())
            {
                ieRoles = ieRoles.Where(r => r.Id == Criteria.Uuid);
            }

            if (!Criteria.Name.IsNullOrWhiteSpace())
            {
                ieRoles = ieRoles.Where(r => r.Name == Criteria.Name);
            }

            IEnumerable<RoleDto> ieDto = from role in ieRoles
                                         select new RoleDto
                                         {
                                             Name = role.Name,
                                             Uuid = role.Id
                                         };

            OperationResult result = new OperationResult();
            result.Items = ieDto.ToArray();
            result.Status = true;
            return result;
        }
    }
}