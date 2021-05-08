using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TBLKategori.Where(x => x.DURUM == true).ToList();
            return View(degerler);
        }

        [HttpGet]   //Sayfa yenilendiğine bu çalışsın
        public ActionResult KategoriEkle()
        {
             return View();
        }

        [HttpPost]  //Bir gönderme işlemi olduğunda bu çalışsın
        public ActionResult KategoriEkle(TBLKategori p)
        {
            db.TBLKategori.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKategori.Find(id);
            //db.TBLKategori.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKategori.Find(id);
                    
            return View("KategoriGetir",kategori);
        }

        public ActionResult KategoriGuncelle(TBLKategori p)
        {
            var ktg = db.TBLKategori.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}