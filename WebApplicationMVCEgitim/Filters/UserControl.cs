using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var UserGuidSession = filterContext.HttpContext.Session["userguid"];
            var UserGuidCookie = filterContext.HttpContext.Request.Cookies["userguid"];
            if (UserGuidSession == null)
            {
                filterContext.Result = new RedirectResult("/MVC12Session?msg=AccessDenied");
            }
            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // action çalışmaya başladığında filtre kullanmak istersek
            base.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}