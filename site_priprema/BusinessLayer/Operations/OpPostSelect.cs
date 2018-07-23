using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.Criterias;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{
	public class OpPostSelect : OpPostsBase
    {
        public PostCriteria criteria = new PostCriteria();

        

        public override OperationResult Execute(VlogEntities entities)
        {
            OperationResult result = new OperationResult();
            

            if (this.Postdto.CategoryID == 0 && this.criteria.Id != 0)
            {
                IEnumerable<PostDto> postsC = from posts in entities.Posts
                                              join user in entities.AspNetUsers
                                              on posts.UserID equals user.Id
                                              join categories in entities.Categories
                                              on posts.CategoryID equals categories.CategoryID
                                              where posts.PostID == this.criteria.Id
                                              //  join comments in entities.Comments
                                              //on posts.PostID equals comments.PostID into koment
                                              //  from k in koment.DefaultIfEmpty(new Comment()
                                              //  {

                                              //  })

                                              //where posts.PostID == k.PostID
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
                                                  Username = user.UserName,
                                                  //Comment =  (from comment in k
                                                  //           select new CommentDto
                                                  //           {
                                                  //               Comment = comment.Comment1
                                                  //           }).ToList()
                                              };

                List<PostDto> z = postsC.ToList();

                foreach (var i in z)
                {
                    IEnumerable<CommentDto> comments = from c in entities.Comments
                                                       join users in entities.AspNetUsers
                                                       on c.AspNetUser.Id equals users.Id
                                                       where c.PostID == i.Id
                                                       where c.AspNetUser.Id == users.Id
                                                       select new CommentDto
                                                       {
                                                           Comment = c.Comment1,
                                                           Created_At = c.Created_At,
                                                           Updated_At = c.Updated_At,
                                                           AspNetUser = (from user in entities.AspNetUsers
                                                                         where user.Id == c.UserID
                                                                         select new UserDto
                                                                         {
                                                                             UserName = user.UserName
                                                                         }).FirstOrDefault()
                                                       };
                    i.Comment = comments.ToList();
                }




                result.Items = z.ToArray();
                result.Status = true;
                return result;
            }
            else if(this.Postdto.CategoryID != 0)
            {
                IEnumerable<PostDto> customPosts = from posts in entities.Posts
                                                   join user in entities.AspNetUsers
                                                   on posts.UserID equals user.Id
                                                   join categories in entities.Categories
                                                   on posts.CategoryID equals categories.CategoryID
                                                   where posts.CategoryID == this.Postdto.CategoryID
                                                   //  join comments in entities.Comments
                                                   //on posts.PostID equals comments.PostID into koment
                                                   //  from k in koment.DefaultIfEmpty(new Comment()
                                                   //  {

                                                   //  })

                                                   //where posts.PostID == k.PostID
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
                                                       Username = user.UserName,
                                                       //Comment =  (from comment in k
                                                       //           select new CommentDto
                                                       //           {
                                                       //               Comment = comment.Comment1
                                                       //           }).ToList()
                                                   };

                List<PostDto> p = customPosts.ToList();

                foreach (var i in p)
                {
                    IEnumerable<CommentDto> comments = from c in entities.Comments
                                                       where c.PostID == i.Id
                                                       select new CommentDto
                                                       {
                                                           Comment = c.Comment1
                                                       };
                    i.Comment = comments.ToList();
                }



                result.Items = p.ToArray();
                result.Status = true;
                return result;
            }
            else 
            {
                return base.Execute(entities);
            }
            
            
        }
    }
}