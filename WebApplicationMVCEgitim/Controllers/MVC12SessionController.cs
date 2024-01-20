using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCEgitim.Models;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC12SessionController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC12Session
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre); // üyeler tablosunda formdan gönderilen kullanıcı adı ve şifreyle eşleşen 1 kayıt var mı?
            if (kullanici != null) // eğer kullanıcı db de varsa
            {
                Session["deger"] = "Admin"; // adı deger olan bir session oluştur
                Session["userguid"] = Guid.NewGuid().ToString();
                Session["kullanici"] = kullanici; // session obje alabildiği için her türlü veri yükleyebiliyoruz
                return RedirectToAction("SessionOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return View("Index");
        }
        public ActionResult SessionOku()
        {
            TempData["SessionBilgi"] = Session["deger"]; // deger isimli session ın üzerindeki veriyi tempdataya aktar
            return View();
        }
        public ActionResult SessionSil()
        {
            //Session["deger"] = null; // deger isimli session ın üzerindeki veriyi tempdataya aktar
            //HttpContext.Session.Remove("kullanici");
            //Session["userguid"] = string.Empty;
            Session.RemoveAll(); // tüm sessionları sil
            return RedirectToAction("Index");
        }
    }
}