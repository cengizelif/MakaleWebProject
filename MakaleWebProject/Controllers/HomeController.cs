using Makale.BusinessLayer;
using Makale.Entities;
using MakaleWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace MakaleWebProject.Controllers
{
    public class HomeController : Controller
    {
    
        MakaleYonet my = new MakaleYonet();
        KategoriYonet ky = new KategoriYonet();

        public ActionResult Index()
        {
           return View(my.MakaleGetir().OrderByDescending(x=>x.DegistirmeTarihi).ToList());
        }

        public ActionResult Kategori(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           
            Kategori kat=ky.KategoriBul(id.Value);

            if(kat==null)
            {
                return HttpNotFound();
            }

            return View("Index",kat.Makaleler);
        }

        public ActionResult EnBegenilenler()
        {
            return View("Index", my.MakaleGetir().OrderByDescending(x => x.BegeniSayisi).ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("RegisterOK");
            }

            return View();
        }

        public ActionResult RegisterOK()
        {
            return View();
        }

    }
}