using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        // GET: MVC03DataTransfer : Mvc de ekrandan controller a ve controller dan ekrana veri yollamamızı sağlayan yöntemler.
        public ActionResult Index()
        {
            // 3 Farklı Yöntemle Controllerdan View a Basit Veriler Gönderebiliriz

            // 1-Viewbag : Tek kullanımlık ömrü vardır.
            ViewBag.UrunKategorisi = "Bilgisayar"; // Burada ViewBag ismi standart olarak yazılır sonrasında . deyip dilediğimiz değişken adını yazabiliriz.

            return View();
        }
    }
}