using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}