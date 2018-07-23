using site_priprema.BusinessLayer;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.BusinessLayer.Operations;
using site_priprema.BusinessLayer.Operations.Delete;
using site_priprema.BusinessLayer.Operations.Inserts;
using site_priprema.BusinessLayer.Operations.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site_priprema.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        OperationManager _manager = OperationManager.Singleton;
        // GET: Admin/Category
        public ActionResult Index()
        {
            OpCategoriesSelect selectCategories = new OpCategoriesSelect();
            OperationResult result = _manager.ExecuteOperation(selectCategories);
            return View(result.Items as CategoryDto[]);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(CategoryDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                OpCategoryInsert insert = new OpCategoryInsert();
                insert.category = dto;
                var result = _manager.ExecuteOperation(insert);
                if (result.Status)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                return View(dto);
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryDto dto)
        {
            try
            {
                // TODO: Add update logic here
                OpCategoryUpdate updateCat = new OpCategoryUpdate();
                updateCat.category = dto;
                OperationResult result = _manager.ExecuteOperation(updateCat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dto);
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(CategoryDto dto)
        {
            try
            {
                // TODO: Add delete logic here
                OpCategoryDelete delete = new OpCategoryDelete();
                delete.Id = dto.Id;
                var result = _manager.ExecuteOperation(delete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dto);
            }
        }
        private CategoryDto getInstance(int id)
        {
            OpCategoriesBase op = new OpCategoriesBase();
            op.Criteria.Id = id;
            var result = _manager.ExecuteOperation(op);
            CategoryDto dto = result.Items[0] as CategoryDto;
            return dto;
        }
    }
}
