using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.OpenAccess;

namespace YouthConference.Controllers
{
    public class BaseController : Controller
    {
        private readonly OpenAccessContext _context;

        protected BaseController(OpenAccessContext context)
        {
            _context = context;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if ((!filterContext.IsChildAction && (filterContext.Exception == null)) && (_context != null))
            {
                _context.SaveChanges(ConcurrencyConflictsProcessingMode.StopOnFirst);
            }
        }
    }
}
