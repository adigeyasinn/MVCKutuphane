using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa=1) //Projem default olarak kaçıncı sayfadan başlasın onu ayarlar
        {
            // var degerler = db.TBLUyeler.ToList();
            var degerler = db.TBLUyeler.ToList().ToPagedList(sayfa, 3); //her sayfada 3 tane olacak şekilde gösterir
            return View(degerler);
        }

        [HttpGet]   //Sayfa yenilendiğine bu çalışsın
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]  //Bir gönderme işlemi olduğunda bu çalışsın
        public ActionResult UyeEkle(TBLUyeler p)
        {
            if (!ModelState.IsValid)//  data annotaion şartı sağlamadıysa
            {
                return View("UyeEkle");
            }
            db.TBLUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUyeler.Find(id);
            db.TBLUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUyeler.Find(id);

            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUyeler p)
        {
            var uye = db.TBLUyeler.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAİL = p.MAİL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}