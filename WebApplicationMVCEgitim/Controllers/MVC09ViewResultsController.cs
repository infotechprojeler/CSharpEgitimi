using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC09ViewResultsController : Controller
    {
        // GET: MVC09ViewResults
        public ActionResult Index()
        {
            return View();
        }
    }
}