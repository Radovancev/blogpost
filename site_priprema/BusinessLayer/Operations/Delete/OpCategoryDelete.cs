using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations.Delete
{
    public class OpCategoryDelete : OpCategoriesBase
    {
        public int Id { get; set; }
        public override OperationResult Execute(VlogEntities entities)
        {
            Category category = entities.Categories.Where(r => r.CategoryID == Id).FirstOrDefault();
            if (category != null)
            {
                entities.Categories.Remove(category);
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "Kategorija ne postoji.";
                return result;
            }
        }
    }
}