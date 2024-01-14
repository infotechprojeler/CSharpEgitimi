using System.IO; // Uygulamanın sunucusundaki dosya ve klasörleri yönetebilmemizi sağlayan kütüphane
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCEgitim.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        // GET: MVC10FileUpload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dosya) // dosya yüklemek için gereken parametre. Burada dosya yazan yer ekrandaki file inputunda yazan name değeriyle aynı olmalı yoksa dosya yüklenmez!!!
        {
            if (dosya != null && dosya.ContentLength > 0) // eğer formdan bir dosya seçilip yollanmışsa
            {
                var uzanti = Path.GetExtension(dosya.FileName).ToLower(); // yüklenen dosyanın uzantısını yakalıyoruz
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif") // dosya uzantısını kontrol ediyoruz, sadece istediğimiz dosya tiplerine izin vermek için
                {
                    // 1. Yöntem : Random(Rasgele) İsimle Dosya Yükleme
                    var klasor = Server.MapPath("/Images"); // resmi yükleyeceğimiz klasör. (Sunucuda bu klasör yoksa hata verir)
                    var klasorVarmi = Directory.Exists(klasor); // sunucuda bu klasör var mı?
                    TempData["Message"] = "klasorVarmi : " + klasorVarmi;
                    if (klasorVarmi == false) // eğer sunucuda bu konumda klasör yoksa
                    {
                        Directory.CreateDirectory(klasor); // ana dizine Images klasörü oluştur
                        TempData["Message"] += " - Klasör Oluşturuldu..";
                    }
                    var randomFileName = Path.GetRandomFileName();
                    var fileName = Path.ChangeExtension(randomFileName, uzanti);
                    var path = Path.Combine(klasor, fileName);
                    //dosya.SaveAs(path);
                    //ViewBag.ResimAdi = fileName;

                    // 2. Yöntem - Resmi Kendi Adıyla Yükleme
                    var dosyaAdi = Path.GetFileName(dosya.FileName);
                    var yol = Path.Combine(klasor, dosyaAdi);
                    //dosya.SaveAs(yol);
                    //ViewBag.ResimAdi = dosyaAdi;

                    // 3. Yöntem : Resmi direk sunucuya yollama
                    dosya.SaveAs(Server.MapPath("/Images/" + dosya.FileName));
                    ViewBag.ResimAdi = dosya.FileName;
                }
                else
                    TempData["Message"] = "Sadece Resim Dosyası Yükleyebilirsiniz!";
            }
            return View();
        }
    }
}