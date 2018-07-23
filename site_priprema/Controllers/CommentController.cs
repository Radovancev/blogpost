using Microsoft.AspNet.Identity;
using site_priprema.BusinessLayer;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.BusinessLayer.Operations;
using site_priprema.BusinessLayer.Operations.Inserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site_priprema.Controllers
{
    public class CommentController : Controller
    {
        OperationManager _manager = OperationManager.Singleton;
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(string Comment, int PostID)
        {
            try
            {
                // TODO: Add insert logic here
                OpInsertComment insertComment = new OpInsertComment();
                insertComment.Comment.PostID = PostID;
                insertComment.Comment.Comment = Comment;
                insertComment.Comment.UserID = User.Identity.GetUserId();
                OperationResult result = _manager.ExecuteOperation(insertComment);

                OpPostSelect selectCommentsForPost = new OpPostSelect();
                selectCommentsForPost.criteria.Id = PostID;
                OperationResult rez = _manager.ExecuteOperation(selectCommentsForPost);
                IEnumerable<PostDto> post = rez.Items as PostDto[];
                result.Message = "Uspesno dodato!";
                return Json(post, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
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
    }
}
