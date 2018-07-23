using site_priprema.BusinessLayer;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.BusinessLayer.Operations;
using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site_priprema.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActivityLogController : Controller
    {
        OperationManager _manager = OperationManager.Singleton;
        VlogEntities ent = new VlogEntities();
        // GET: Admin/ActivityLog
        public ActionResult Index()
        {
            OpActivityLogBase selectActivity = new OpActivityLogBase();
            OperationResult result = _manager.ExecuteOperation(selectActivity);

            return View();
        }

        // GET: Admin/ActivityLog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ActivityLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ActivityLog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ActivityLog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ActivityLog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ActivityLog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ActivityLog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Activity()
        {
            return Json(ent.ActionLogs.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
