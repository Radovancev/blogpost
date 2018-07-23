using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using site_priprema.BusinessLayer.Criterias;
using site_priprema.BusinessLayer.DTOs;
using site_priprema.DataLayer;

namespace site_priprema.BusinessLayer.Operations
{
    public class OpActivityLogBase : Operation
    {
        public ActivityLogDto ActivityLog = new ActivityLogDto();
        public ActivityLogCriteria Criteria = new ActivityLogCriteria();

        public override OperationResult Execute(VlogEntities entities)
        {
            IEnumerable<ActivityLogDto> ieActivity = from log in entities.ActionLogs
                                                     select new ActivityLogDto
                                                     {
                                                         Id = log.ActionLogId,
                                                         Action = log.Action,
                                                         Controller = log.Controller,
                                                         DateTime = log.DateTime,
                                                         IP = log.IP
                                                     };
            OperationResult result = new OperationResult();
            result.Items = ieActivity.ToArray();
            result.Status = true;
            return result;
        }
    }
}