using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{
	public abstract class OpPostsBase : Operation
	{
        public PostDto Postdto = new PostDto();

        public override OperationResult Execute(VlogEntities entities)
		{
            IEnumerable<PostDto> iePosts = from posts in entities.Posts
                                           join user in entities.AspNetUsers
                                           on posts.UserID equals user.Id
                                           join categories in entities.Categories
                                           on posts.CategoryID equals categories.CategoryID
                                           select new PostDto
                                           {
                                               Id = posts.PostID,
                                               Post = posts.Post1,
                                               Path = posts.Path,
                                               Text = posts.Text,
                                               UserID = posts.UserID,
                                               Uuid = posts.UserID,
                                               Created_At = posts.Created_At,
                                               Updated_At = posts.Updated_At,
                                               CategoryID = posts.CategoryID,
                                               Username = user.UserName
                                           };

			
			OperationResult result = new OperationResult();
			result.Items = iePosts.ToArray();
			result.Status = true;
			return result;
		}
	}
}