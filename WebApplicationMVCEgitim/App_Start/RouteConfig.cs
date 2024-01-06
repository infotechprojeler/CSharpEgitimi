using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationMVCEgitim
{
    public class RouteConfig // Bu dosya mvc nin çalışma sistemini ayarlar. Kullanıcı hangi ekranı açmak isterse arka tarafta hangi controller dosyasını ve onun içinde hangi action ın çalışacağını burası ayarlar.
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute( // ayarların yapılandırıldığı metot
                name: "Default", // route ayarının adı
                url: "{controller}/{action}/{id}", // uygulamanın url çalışma sisteminin ayarlandığı kısım
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // defaults kısmı ise herhangi bir controller ve action adı yazılmazsa varsayılan olarak hangi ekranın açılacağını ayarladığımız kısım.
            );
        }
    }
}
