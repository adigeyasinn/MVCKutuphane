using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
using MVCKutuphane.Models.Siniflarim;
namespace MVCKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
       [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKitap.ToList();
            cs.Deger2 = db.TBLHakkımızda.ToList();
            //var degerler = db.TBLKitap.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLİletişim t)
        {
            db.TBLİletişim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}