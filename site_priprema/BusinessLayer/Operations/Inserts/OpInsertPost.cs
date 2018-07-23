using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{
    public class OpInsertPost : OpPostsBase
    {

        public override OperationResult Execute(VlogEntities entities)
        {
            Post post = new Post();
            post.CategoryID = this.Postdto.CategoryID;
            post.Created_At = DateTime.Now;
            post.Updated_At = DateTime.Now;
            post.Post1 = this.Postdto.Post;
            post.Text = this.Postdto.Text;
            post.UserID = this.Postdto.UserID;
            post.Path = this.Postdto.Path;

            entities.Posts.Add(post);
            entities.SaveChanges();
            return base.Execute(entities);
        }
    }
}