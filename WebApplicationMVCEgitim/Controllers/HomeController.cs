using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class HomeController : Controller
    {
        // Controller uygulamayı kullanan kullanıcıların süreçlerini yönetir. Mesela veritabanından ürünlerin çekilip ekrana gönderilmesi veya ekrandan alınan ürün bilgisinin veritabanına kaydedilmesi gibi tüm süreçler burada yönetilir.
        // MVC de Controller isimleri Controller ile bitmek zorundadır! HomeController, ProductController vb gibi.
        public ActionResult Index()
        {
            // Burası kullanıcıya veri gönderebildiğimiz bölümdür.
            return View(); // Kullanıcıya göstermek istediğimiz ekranı return view ile sağlarız.
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda sayfası.";

            return View();
        }

        public ActionResult Urunlerimiz()
        {
            ViewBag.Message = "Ürünlerimiz";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Adres Bilgilerimiz : "; // Not: controller larda yaptığımız değişikliklerin ekrana yansıması için üst menüden projeyi tekrar buil etmemiz lazım!!

            return View();
        }
    }
}