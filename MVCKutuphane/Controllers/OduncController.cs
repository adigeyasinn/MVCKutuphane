using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class OduncController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler = db.TBLHareket.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBLUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD+" "+x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in db.TBLKitap.Where(z=>z.DURUM==true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD ,
                                              Value = x.ID.ToString()
                                          }).ToList();
            List<SelectListItem> deger3 = (from x in db.TBLPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }


        [HttpPost]  //Bir gönderme işlemi olduğunda bu çalışsın
        public ActionResult OduncVer(TBLHareket p)
        {
            var d1 = db.TBLUyeler.Where(k => k.ID == p.TBLUyeler.ID).FirstOrDefault();
            var d2 = db.TBLKitap.Where(k => k.ID == p.TBLKitap.ID).FirstOrDefault();
            var d3 = db.TBLPersonel.Where(k => k.ID == p.TBLPersonel.ID).FirstOrDefault();
            p.TBLUyeler = d1;
            p.TBLKitap = d2;
            p.TBLPersonel = d3;
            db.TBLHareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Oduncİade(TBLHareket t)
        {
            var odn = db.TBLHareket.Find(t.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Oduncİade", odn);

        }
        public ActionResult OduncGuncelle(TBLHareket p)
        {
            var prs = db.TBLHareket.Find(p.ID);
            prs.UYEGETİRTARİH = p.UYEGETİRTARİH;
            prs.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}