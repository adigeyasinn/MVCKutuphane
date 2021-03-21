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
            var degerler = db.TBLHareket.ToList();
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
    }
}