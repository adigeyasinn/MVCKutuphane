using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class İstatistikController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: İstatistik
        public ActionResult Index()
        {
            var deger1 = db.TBLUyeler.Count();
            var deger2 = db.TBLKitap.Count();
            var deger3 = db.TBLKitap.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBLCezalar.Sum(x => x.PARA);
            ViewBag.dg1 = deger1;
            ViewBag.dg2 = deger2;
            ViewBag.dg3 = deger3;
            ViewBag.dg4 = deger4;

            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength>0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKitap.Count();
            var deger2 = db.TBLUyeler.Count();
            var deger3 = db.TBLCezalar.Sum(x => x.PARA);
            var deger4 = db.TBLKitap.Where(x => x.DURUM==false).Count();
            var deger5 = db.TBLKategori.Count();
            var deger11 = db.TBLİletişim.Count();
            var deger9 = db.TBLKitap.GroupBy(x => x.YAYINEVI).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger6 = db.EnfazlaÜyee().FirstOrDefault();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr6 = deger6;
            
            return View();
        }
    }
}