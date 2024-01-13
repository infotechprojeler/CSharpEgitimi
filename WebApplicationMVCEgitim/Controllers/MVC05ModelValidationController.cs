using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCEgitim.Models;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        // GET: MVC05ModelValidation
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet] // varsayılan zaten get olduğu için HttpGet i yazmasak da olur
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost] // attribute ler her zaman action ların üzerine yazılır!!
        public ActionResult YeniUye(Uye uye)
        {
            if (ModelState.IsValid) // model classımız kurallara uygun bir şekilde gönderilmişse
            {
                // bu bloktaki kodları çalılştır, mesela gelen nesneyi veritabanına ekle
                return RedirectToAction("Index"); // işlemler tamamlanınca anasayfaya dön
            }
            ModelState.AddModelError("", "Lütfen Tüm Zorunlu Alanları Doldurunuz!"); // ekrandaki hata mesajı gösterme alanına özel hata mesajlarımızı bu şekilde gönderebiliriz.
            return View(uye); // eğer validasyondan geçilmemişse gelen uye nesnesini hatalarıyla tekrar ekrana gönder
        }
    }
}