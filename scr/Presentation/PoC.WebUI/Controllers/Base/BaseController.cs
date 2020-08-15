using System.Web.Mvc;
using PoC.Domain.Interfaces;
using Ninject;
using System;

namespace PoC.WebUI.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {            
            try
            {
                if (!filterContext.IsChildAction)
                    UnitOfWork.BeginTransaction();
            }
            catch { }
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                if (!filterContext.IsChildAction)
                    UnitOfWork.Commit();
            }
            catch { }
        }
    }
}
