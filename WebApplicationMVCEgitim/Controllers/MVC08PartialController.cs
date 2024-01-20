using System.Linq;
using System.Web.Mvc;
using WebApplicationMVCEgitim.Models;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC08PartialController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC08Partial
        public ActionResult Index()
        {
            return View(context.Uyeler.ToList());
        }
    }
}