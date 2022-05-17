﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using odev_internetP.Models.Sınıflar;
using odev_internetP.Models.Siniflar;

namespace odev_internetP.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            //  var bloglar = c.Blogs.ToList(); 
            by.Deger1 = c.Blogs.ToList();
            by.Deger3=c.Blogs.Take(3).ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2= c.Yorumlars.Where(x => x.Blogid == id).ToList();
           // var blogbul=c.Blogs.Where(x => x.ID == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();

        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}