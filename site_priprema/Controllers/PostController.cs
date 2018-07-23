using Microsoft.AspNet.Identity;
using PagedList;
using site_priprema.BusinessLayer;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.BusinessLayer.Operations;
using site_priprema.Filters;
using site_priprema.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site_priprema.Controllers
{
    public class PostController : Controller
    {
		OperationManager _manager = OperationManager.Singleton;
		// GET: Global/Post
		public ActionResult Index(int? page)
		{
            OpPostSelect op = new OpPostSelect();
			OperationResult result = _manager.ExecuteOperation(op);

            OpCategoriesSelect opCategories = new OpCategoriesSelect();
            OperationResult res = _manager.ExecuteOperation(opCategories);

            PostCategories postCategories = new PostCategories();

            postCategories.Categories = res.Items as CategoryDto[];
            postCategories.Posts = result.Items as PostDto[];

            OpMenuBase menus = new OpMenuBase();
            OperationResult res1 = _manager.ExecuteOperation(menus);
            ViewBag.menus = res1.Items as MenuDto[];

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            IPagedList<PostDto> posts = postCategories.Posts.ToPagedList(pageNumber, pageSize);
            postCategories.ListaPaged = posts;

            return View(postCategories);
		}

		// GET: Post/Details/5
		public ActionResult Details(int id)
        {
            OpPostSelect select = new OpPostSelect();
            select.criteria.Id = id;
            OperationResult result = new OperationResult();
            result = _manager.ExecuteOperation(select);
            PostDto dto = result.Items[0] as PostDto;
            return View(dto);
        }

        [LogRequestAttribute]
        public ActionResult Custom(int? page,int id)
        {
            OpPostSelect select = new OpPostSelect();
            select.Postdto.CategoryID = id;
            OperationResult result = _manager.ExecuteOperation(select);

            OpCategoriesSelect opCategories = new OpCategoriesSelect();
            OperationResult res = _manager.ExecuteOperation(opCategories);

            PostCategories postCategories = new PostCategories();

            postCategories.Categories = res.Items as CategoryDto[];
            postCategories.Posts = result.Items as PostDto[];

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            IPagedList<PostDto> posts = postCategories.Posts.ToPagedList(pageNumber, pageSize);
            postCategories.ListaPaged = posts;

            return View(postCategories);
        }

        // GET: Post/Create
        [Authorize]
        [LogRequestAttribute]
        public ActionResult Create()
        {
            ViewBag.categories = _manager.ExecuteOperation(new OpCategoriesSelect()).Items as CategoryDto[];
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [LogRequestAttribute]
        public ActionResult Create(PostViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                   
                    PostDto postDto = new PostDto
                    {
                        Post = model.Post1,
                        Text = model.Text,
                        CategoryID = model.CategoryID,
                        UserID = User.Identity.GetUserId()
                    };
                    string fileName = Guid.NewGuid().ToString() + "_" + model.Path.FileName;
                    string putanja = Path.Combine(Server.MapPath("~/Content/Images"), fileName);

                    model.Path.SaveAs(putanja);
                    postDto.Path = "Content/Images/" + fileName;
                    OpInsertPost insertPost = new OpInsertPost();
                    insertPost.Postdto = postDto;

                    var result = _manager.ExecuteOperation(insertPost);
                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    ViewBag.categories = _manager.ExecuteOperation(new OpCategoriesSelect()).Items as CategoryDto[];
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
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

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
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
