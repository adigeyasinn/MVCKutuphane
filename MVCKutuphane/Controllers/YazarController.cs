using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
namespace MVCKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYazar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle() //ctrl+k+d kodu düzeltir
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TBLYazar p)
        {
            if (!ModelState.IsValid) //Model üzerinde yaptığım işlem geçerli değilse yazarekleye döndür
            {
                return View("YazarEkle");
            }
            db.TBLYazar.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYazar.Find(id);
            db.TBLYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLYazar.Find(id);
            return View("YazarGetir", yzr);
        }

        public ActionResult YazarGuncelle(TBLYazar p)
        {
            var yzr = db.TBLYazar.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TBLKitap.Where(x => x.YAZAR == id).ToList();
            var yzrad = db.TBLYazar.Where(k => k.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(yazar);
        }
    }
}