using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC13StringFormatController : Controller
    {
        // GET: MVC13StringFormat
        public ActionResult Index()
        {
            ViewBag.Data = string.Format("M{0:D6}", 1);
            ViewBag.Data2 = string.Format("S{0:D6}", 118);
            return View();
        }
    }
}