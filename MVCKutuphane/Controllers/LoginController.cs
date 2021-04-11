using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
using System.Web.Security;

namespace MVCKutuphane.Controllers
{
    public class LoginController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUyeler p)
        {
            var bilgiler = db.TBLUyeler.FirstOrDefault(x => x.MAİL == p.MAİL && x.SIFRE == p.SIFRE);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAİL, false);
                Session["Mail"] = bilgiler.MAİL.ToString();
                //TempData["Id"] = bilgiler.ID.ToString();
                //TempData["Ad"] = bilgiler.AD.ToString();
                //TempData["Soyad"] = bilgiler.SOYAD.ToString();
                //TempData["KullanıcıAdı"] = bilgiler.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgiler.SIFRE.ToString();
                //TempData["Okul"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index","Panelim");
            }
            else
            {
                return View();
            }
            
        }
    }
}