using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site_priprema.BusinessLayer.Operations
{
    public abstract class OpCommentBase : Operation
    {
        public CommentDto Comment = new CommentDto();
        public override OperationResult Execute(VlogEntities entities)
        {
            IEnumerable<CommentDto> comments = from comment in entities.Comments
                                               join users in entities.AspNetUsers
                                               on comment.UserID equals users.Id
                                               where comment.UserID == users.Id
                                               select new CommentDto
                                               {
                                                   UserID = comment.UserID,
                                                   Comment = comment.Comment1,
                                                   Id = comment.CommentID,
                                                   Created_At = comment.Created_At,
                                                   Updated_At = comment.Updated_At,
                                                   PostID = comment.PostID
                                               };

            OperationResult result = new OperationResult();
            result.Items = comments.ToArray();
            result.Status = true;
            return result;
        }
    }
}