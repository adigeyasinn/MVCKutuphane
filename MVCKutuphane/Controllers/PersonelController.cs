using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
namespace MVCKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPersonel.ToList();
            return View(degerler);
        }


        [HttpGet]   //Sayfa yenilendiğine bu çalışsın
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]  //Bir gönderme işlemi olduğunda bu çalışsın
        public ActionResult PersonelEkle(TBLPersonel p)
        {
            if (!ModelState.IsValid)//  data annotaion şartı sağlamadıysa
            {
                return View("PersonelEkle");
            }
            db.TBLPersonel.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var prs = db.TBLPersonel.Find(id);
            db.TBLPersonel.Remove(prs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPersonel.Find(id);

            return View("PersonelGetir", prs);
        }

        public ActionResult PersonelGuncelle(TBLPersonel p)
        {
            var prs = db.TBLPersonel.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}