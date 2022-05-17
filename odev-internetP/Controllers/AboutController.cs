using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using odev_internetP.Models.Sınıflar;

namespace odev_internetP.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList();
            return View(degerler);
        }
    }
}