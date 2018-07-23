using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations.Inserts
{
    public class OpInsertComment : OpCommentBase
    {
        public override OperationResult Execute(VlogEntities entities)
        {
            Comment commentDtos = new Comment();
            commentDtos.UserID = this.Comment.UserID;
            commentDtos.Comment1 = this.Comment.Comment;
            commentDtos.Created_At = DateTime.Now;
            commentDtos.Updated_At = DateTime.Now;
            commentDtos.PostID = this.Comment.PostID;

            OperationResult result = new OperationResult();
            entities.Comments.Add(commentDtos);
            entities.SaveChanges();
            
            return base.Execute(entities);
        }
    }
}