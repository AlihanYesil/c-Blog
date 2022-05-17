using odev_internetP.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace odev_internetP.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgiler= c.admins.FirstOrDefault(x=>x.Kullanici==ad.Kullanici && x.Sifre==ad.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }

        }
        public ActionResult LogOut(Admin ad)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}