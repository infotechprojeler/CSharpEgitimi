using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCEgitim.Filters;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        // GET: MVC15FiltersUsing
        public ActionResult Index()
        {
            // ViewBag.Kullanici = Session["userguid"];
            return View();
        }
        [UserControl]
        public ActionResult FiltreKullanimi()
        {
            TempData["Kullanici"] = Session["userguid"];
            return RedirectToAction("Index");
        }
    }
}