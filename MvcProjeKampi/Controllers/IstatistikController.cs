using BusinessLayer;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c=new Context();
   

        public int ToplamKategori()
        {
            return c.Categories.Count();
        }
        public int BaslikSayisi()
        {
            int kategoriID=c.Categories.Where(x=>x.CategoryName=="Yazılım").Select(x=>x.CategoryID).FirstOrDefault();
            int baslikSayisi=c.Headings.Where(y=>y.CategoryID==kategoriID).Count();
           

            return baslikSayisi;
        }
        public List<Writer> YazarAdi()
        {
            var y=c.Writers.Where(x => x.WriterName.Contains("a")).ToList();
            return y;
         
        }

        public dynamic MaxHeadings()
        {
            return c.Headings
      .GroupBy(b => b.Category) // Başlıkları Kategori'ye göre grupluyoruz
      .OrderByDescending(g => g.Count()) // Grupları başlık sayısına göre azalan sıraya koyuyoruz
      .Select(g => new
      {
          KategoriAdi = g.Key.CategoryName, // Kategori adı
          BaslikSayisi = g.Count() // Başlık sayısı
      })
      .FirstOrDefault(); // En fazla başlığa sahip kategoriyi alıyoruz

            // Sonucu View'e göndermek için ViewBag kullanıyoruz
            
        }
        public int Fark()
        {
            int dogru = c.Categories.Count(x => x.CategoryStatus == true);
            int yanlis = c.Categories.Count(x => x.CategoryStatus == false);
            int fark = dogru - yanlis;
            return fark;
        }

        public ActionResult Index()
        {
            int toplamKategoriSayisi = ToplamKategori();
            ViewBag.ToplamKategori=toplamKategoriSayisi;
            int baslikSayisi=BaslikSayisi();
            ViewBag.BaslikSayisi=baslikSayisi;
            var yazarAdi=YazarAdi();
            ViewBag.Yazarlar=yazarAdi;
            var kategori = MaxHeadings();
            ViewBag.EnFazlaBaslikliKategori = kategori.KategoriAdi;
            ViewBag.BaslikSayisi = kategori.BaslikSayisi;
            int fark = Fark();
            ViewBag.Fark = fark;
            return View();
        }
    }
}