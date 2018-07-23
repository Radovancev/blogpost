using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Updates
{
    public class OpCategoryUpdate : OpCategoriesBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            Category categori = entities.Categories.Where(r => r.CategoryID == category.Id).FirstOrDefault();
            if (categori != null)
            {
                categori.Category1 = category.Category;
                entities.SaveChanges();
                return base.Execute(entities);
            }

            OperationResult result = new OperationResult();
            result.Status = false;
            result.Message = "Kategorija ne postoji.";
            return result;
        }
    }
}