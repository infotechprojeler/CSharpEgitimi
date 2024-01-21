using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        // GET: MVC16HttpContext
        public ActionResult Index()
        {
            // Request.QueryString["ReturnUrl"] : burada adres çubuğundaki ReturnUrl isimli QueryString nesnesini yakalayıp işleyebiliyoruz. Kullanıcıyı burada yer alan ekrana yönlendirmek için mesela.
            // Request.QueryString["UrunAdi"] : bu şekilde adres çubuğundan gönderilen ürün adını yakalayıp veritabanında eşleşen kayıtları bulup kullanıcıya ilgili ürünleri sunabiliriz.
            return View();
        }
    }
}