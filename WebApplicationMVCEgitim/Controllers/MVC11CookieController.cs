using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCEgitim.Models;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC11CookieController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC11Cookie
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre); // üyeler tablosunda formdan gönderilen kullanıcı adı ve şifreyle eşleşen 1 kayıt var mı?
            if (kullanici != null) // eğer girilen bilgilerle eşleşen bir kayıt varsa
            {
                // tarayıcıda 1 cookie oluştur
                HttpCookie cookie = new HttpCookie("username", kullaniciAdi) // oluşacak cookie nin adı ve değeri
                {
                    Expires = DateTime.Now.AddMinutes(3) // oluşan cookie 3 dk geçerli olsun, sonrasında geçersiz olsun
                };
                Response.Cookies.Add(cookie); // çerezi kaydet
                HttpContext.Response.Cookies.Add(new HttpCookie("userguid", Guid.NewGuid().ToString())); // userguid isminde 1 çerez daha oluştur ve içinde o kullanıcıya özel şifreli bir değer sakla
                return RedirectToAction("CookieOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>
                    Giriş Başarısız!
                </div>";
            return RedirectToAction("Index");
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["username"] != null)
            {
                TempData["Mesaj"] = HttpContext.Request.Cookies["username"].Value;
            }
            if (HttpContext.Request.Cookies["userguid"] != null)
            {
                TempData["KullaniciGuid"] = HttpContext.Request.Cookies["userguid"].Value;
            }
            return View();
        }
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["username"] != null)
            {
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddMinutes(-1); // Expires cookie nin bitiş tarihi, buraya geçmişe yönelik herhangi bir değer atadığımızda cookie geçersiz olur.
            }
            if (HttpContext.Request.Cookies["userguid"] != null)
            {
                HttpContext.Response.Cookies["userguid"].Expires = DateTime.Now.AddMinutes(-1);
            }
            return RedirectToAction("CookieOku");
        }
    }
}