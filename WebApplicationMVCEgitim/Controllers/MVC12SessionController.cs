using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC12SessionController : Controller
    {
        // GET: MVC12Session
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionOlustur()
        {
            return View();
        }
    }
}