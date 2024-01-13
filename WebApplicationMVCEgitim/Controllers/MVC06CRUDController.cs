using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC06CRUDController : Controller
    {
        // GET: MVC06CRUD : Entity framework ile veritabanı işlemleri
        public ActionResult Index()
        {
            return View();
        }
    }
}