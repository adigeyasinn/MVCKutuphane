using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
namespace MVCKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Panelim
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUyeler.FirstOrDefault(x => x.MAİL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUyeler.FirstOrDefault(x => x.MAİL == kullanici);
            uye.SIFRE = p.SIFRE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}