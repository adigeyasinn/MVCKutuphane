using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
namespace MVCKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: KayitOl
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}