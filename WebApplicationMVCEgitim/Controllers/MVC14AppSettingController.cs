using System.Web.Configuration; // web configdeki veriyi okumak için gerekli
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        // GET: MVC14AppSetting
        public ActionResult Index()
        {
            ViewBag.MailinGidecegiAdres = WebConfigurationManager.AppSettings["EmailAdres"];
            ViewBag.KullaniciAdi = WebConfigurationManager.AppSettings["EmailUserName"];
            ViewBag.Sifre = WebConfigurationManager.AppSettings["EmailPassword"];
            return View();
        }
    }
}