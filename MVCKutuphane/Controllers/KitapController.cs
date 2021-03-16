using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
   
    public class KitapController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(string p)
        {
            //var kitaplar = db.TBLKitap.ToList();
            var kitaplar = from k in db.TBLKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
            return View(kitaplar.ToList());

        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;  //Taşı

            List<SelectListItem> deger2 = (from i in db.TBLYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD +' '+ i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKitap p)
        {
            var ktg = db.TBLKategori.Where(k => k.ID == p.TBLKategori.ID).FirstOrDefault();
            var yzr = db.TBLYazar.Where(y => y.ID == p.TBLYazar.ID).FirstOrDefault();
            p.TBLKategori = ktg;
            p.TBLYazar = yzr;
            db.TBLKitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult KitapSil(int id)
        {
            var ktp = db.TBLKitap.Find(id);
            db.TBLKitap.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBLKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;  //Taşı

            List<SelectListItem> deger2 = (from i in db.TBLYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }

        public ActionResult KitapGuncelle(TBLKitap p)
        {
            var ktp = db.TBLKitap.Find(p.ID);
            ktp.AD = p.AD;
            ktp.BASIMYIL = p.BASIMYIL;
            ktp.SAYFA = p.SAYFA;
            ktp.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBLKategori.Where(k => k.ID == p.TBLKategori.ID).FirstOrDefault();
            var yzr = db.TBLYazar.Where(y => y.ID == p.TBLYazar.ID).FirstOrDefault();
            ktp.KATEGORI = ktg.ID;
            ktp.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}