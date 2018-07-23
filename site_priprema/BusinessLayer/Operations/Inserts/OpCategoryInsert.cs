using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations.Inserts
{
    public class OpCategoryInsert : OpCategoriesBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            Category category = new Category();
            category.Category1 = this.category.Category;

            entities.Categories.Add(category);
            entities.SaveChanges();
            return base.Execute(entities);
        }
    }
}