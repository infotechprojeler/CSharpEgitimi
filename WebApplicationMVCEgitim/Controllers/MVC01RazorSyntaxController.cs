using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC01RazorSyntaxController : Controller
    {
        // GET: MVC01RazorSyntax
        public ActionResult Index() // Mvc de bir controller ın varsayılan açılış sayfası index tir. Home/Index veya MVC01RazorSyntax/Index gibi..
        {
            // Controller oluşturduğumuzda view ekranı otomatik oluşmaz! buradaki action a sağ klik add view diyerek veya views klasöründeki ilgili alt klasöre sağ klik add view deyip isim vererek oluştururuz.
            return View();
        }
    }
}