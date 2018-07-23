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
    public class MenuController : Controller
    {
        OperationManager _manager = OperationManager.Singleton;
        // GET: Admin/Menu
        public ActionResult Index()
        {
            OpMenuBase menuBase = new OpMenuBase();
            OperationResult result = _manager.ExecuteOperation(menuBase);
            return View(result.Items as MenuDto[]);
        }

        // GET: Admin/Menu/Details/5
        public ActionResult Details(int id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // GET: Admin/Menu/Create
        public ActionResult Create()
        {
            OpMenuBase menus = new OpMenuBase();
            OperationResult result = _manager.ExecuteOperation(menus);
            ViewBag.menus = result.Items as MenuDto[];
            return View();
        }

        // POST: Admin/Menu/Create
        [HttpPost]
        public ActionResult Create(MenuDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                OpInsertMenu insert = new OpInsertMenu();
                insert.Menu = dto;
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
                return View();
            }
        }

        // GET: Admin/Menu/Edit/5
        public ActionResult Edit(int id)
        {
            var dto = getInstance(id);
            OpMenuBase menus = new OpMenuBase();
            OperationResult result = _manager.ExecuteOperation(menus);
            ViewBag.menus = result.Items as MenuDto[];
            return View(dto);
        }

        // POST: Admin/Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(MenuDto dto)
        {
            try
            {
                // TODO: Add update logic here
                OpMenuUpdate updateMenu = new OpMenuUpdate();
                updateMenu.Menu = dto;
                OperationResult result = _manager.ExecuteOperation(updateMenu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Menu/Delete/5
        public ActionResult Delete(int id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost]
        public ActionResult Delete(MenuDto dto)
        {
            try
            {
                // TODO: Add delete logic here
                OpMenuDelete delete = new OpMenuDelete();
                delete.Id = dto.Id;
                var result = _manager.ExecuteOperation(delete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dto);
            }
        }
        private MenuDto getInstance(int id)
        {
            OpMenuBase op = new OpMenuBase();
            op.Criteria.Id = id;
            var result = _manager.ExecuteOperation(op);
            MenuDto dto = result.Items[0] as MenuDto;
            return dto;
        }
    }
}
