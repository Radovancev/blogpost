using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.Criterias;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{
    public class OpCategoriesBase : Operation
    {
        public CategoryDto category = new CategoryDto();
        public CategoryCriteria Criteria = new CategoryCriteria();
        public override OperationResult Execute(VlogEntities entities)
        {
            IEnumerable<Category> ieCategories = entities.Categories;


            if (Criteria.Id != 0)
            {
                ieCategories = ieCategories.Where(r => r.CategoryID == Criteria.Id);
            }
            

            IEnumerable<CategoryDto> ieDto = from category in ieCategories
                                         select new CategoryDto
                                         {
                                             Category = category.Category1,
                                             Id = category.CategoryID
                                         };

            OperationResult result = new OperationResult();
            result.Items = ieDto.ToArray();
            result.Status = true;
            return result;
        }
    }
}