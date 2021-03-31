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
            return View();
        }


        [HttpPost]  //Bir gönderme işlemi olduğunda bu çalışsın
        public ActionResult OduncVer(TBLHareket p)
        {
            db.TBLHareket.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Oduncİade(int id)
        {
            var odn = db.TBLHareket.Find(id);
            
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