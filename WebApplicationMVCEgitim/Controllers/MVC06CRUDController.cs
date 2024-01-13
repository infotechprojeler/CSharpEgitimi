using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCEgitim.Models;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC06CRUDController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC06CRUD : Entity framework ile veritabanı işlemleri
        public ActionResult Index() // Kayıtları index sayfasında listeliyoruz
        {
            return View(context.Uyeler.ToList()); // ekrana bizden beklediği üye listesini veritabanından çeki yolluyoruz
        }
        public ActionResult Create() // yeni kayıt ekleme sayfası
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Uye uye) // yeni kayıt ekleme sayfası
        {
            if (ModelState.IsValid) // uye nesnesi validasyondan geçtiyse
            {
                context.Uyeler.Add(uye); // context e ekle
                int sonuc = context.SaveChanges(); // veritabanına yansıt
                if (sonuc > 0) // ekleme başarılıysa
                {
                    return RedirectToAction("Index"); // liste sayfasına yönlendir
                }
            }
            
            return View(uye); // kayıt başarısız olursa kullanıcıya validasyon hatalarını göster
        }
        public ActionResult Edit(int? id) // kayıt güncelleme sayfası - int? id değerini nullable - boş geçilebilir yapar.
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // geriye geçersiz istek hatası döndür.
            }
            Uye uye = context.Uyeler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (uye == null) // eğer db de kayıt bulamazsan
                return HttpNotFound(); // geriye not found - kayıt bulunamadı ekranı göster
            return View(uye); // eğer kayıt varsa view ekranına gönder
        }
        [HttpPost]
        public ActionResult Edit(Uye uye) // kayıt güncelleme sayfası
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
            return View(uye); // kayıt başarısız olursa kullanıcıya validasyon hatalarını göster
        }
        public ActionResult Delete(int? id) // kayıt silme sayfası - int? id değerini nullable - boş geçilebilir yapar.
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // geriye geçersiz istek hatası döndür.
            }
            Uye uye = context.Uyeler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (uye == null) // eğer db de kayıt bulamazsan
                return HttpNotFound(); // geriye not found - kayıt bulunamadı ekranı göster
            return View(uye); // eğer kayıt varsa view ekranına gönder
        }
        [HttpPost, ActionName("Delete")] // formdan action olarak delete gelecek ve method post olacak
        public ActionResult DeleteConfirmed(int id)
        {
            Uye uye = context.Uyeler.Find(id);
            context.Uyeler.Remove(uye);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}