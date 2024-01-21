using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using WebApplicationMVCEgitim.Filters;
using WebApplicationMVCEgitim.Models;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC15FiltersUsing
        public ActionResult Index()
        {
            return View();
        }
        [UserControl]
        public ActionResult FiltreKullanimi()
        {
            TempData["Kullanici"] = Session["userguid"];
            return RedirectToAction("Index");
        }
        [Authorize] // Authorize attribute ü altındaki action ı oturum açılmamışsa korur ve ekranın açılmasını engeller. Bunu kullanabilmek için web.config dosyasına authentication kodunu ekliyoruz.
        public ActionResult UyeGuncelle(int? id)
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // geriye geçersiz istek hatası döndür.
            }
            Uye uye = context.Uyeler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (uye == null) // eğer db de kayıt bulamazsan
                return HttpNotFound(); // geriye not found - kayıt bulunamadı ekranı göster
            return View(uye);
        }
        [HttpPost, Authorize]
        public ActionResult UyeGuncelle(Uye uye)
        {
            if (ModelState.IsValid) // uye nesnesi validasyondan geçtiyse
            {
                context.Entry(uye).State = System.Data.Entity.EntityState.Modified; // ekrandan gelen uye nesnesini güncellenmek üzere ayarla
                int sonuc = context.SaveChanges(); // veritabanına yansıt
                if (sonuc > 0) // ekleme başarılıysa
                {
                    return RedirectToAction("Index"); // liste sayfasına yönlendir
                }
            }
            return View(uye);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UyeViewModel uye)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var kullanici = context.Uyeler.FirstOrDefault(k => k.Email == uye.Email && k.Sifre == uye.Sifre);
                    if (kullanici == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız!");
                    }
                    else
                    {
                        // eğer giriş başarılıysa
                        Session["userguid"] = Guid.NewGuid().ToString(); // userguid session ı oluştur
                        FormsAuthentication.SetAuthCookie(kullanici.Email, true);
                        if (Request.QueryString["ReturnUrl"] != null) // eğer adres çubuğunda ReturnUrl değeri varsa
                        {
                            return Redirect(Request.QueryString["ReturnUrl"]); // kullanıcıyı login işleminden sonra gitmek istediği adrese yönlendir
                        }
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(uye);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // kullanıcının çıkışını yap
            return RedirectToAction("Index"); // ana ekrana yönlendir
        }
    }
}