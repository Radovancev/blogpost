using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.Criterias;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{
    public class OpMenuBase : Operation
    {
        public MenuCriteria Criteria = new MenuCriteria();
        public MenuDto Menu = new MenuDto();

        
        public override OperationResult Execute(VlogEntities entities)
        {
            IEnumerable<Menu> ieMenus = entities.Menus;


            if (Criteria.Id != 0)
            {
                ieMenus = ieMenus.Where(r => r.MenuID == Criteria.Id);
            }


            IEnumerable<MenuDto> ieMenu = from menus in ieMenus
                                           select new MenuDto
                                           {
                                               Id = menus.MenuID,
                                               Controller = menus.Controller,
                                               Link = menus.Link,
                                               Menu = menus.Menu1,
                                               Area = menus.Area,
                                               ParentID = menus.ParentID
                                           };

            OperationResult result = new OperationResult();
            result.Items = ieMenu.ToArray();
            result.Status = true;
            return result;
        }
    }
}