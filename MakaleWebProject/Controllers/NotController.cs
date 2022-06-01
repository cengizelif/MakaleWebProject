using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Makale.BusinessLayer;
using Makale.Entities;
using MakaleWebProject.Data;

namespace MakaleWebProject.Controllers
{
    public class NotController : Controller
    {
        MakaleYonet my = new MakaleYonet();
        KategoriYonet ky = new KategoriYonet();
       
        public ActionResult Index()
        {
            //var nots = my.MakaleGetir();

            //db.Nots.Include(n => n.Kategori);
            Kullanici user =(Kullanici)Session["login"];

            var nots = my.ListQueryable().Include("Kullanici").Where(x => x.Kullanici.Id == user.Id).OrderByDescending(x => x.DegistirmeTarihi);

            return View(nots.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = my.NotBul(id.Value);

            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(ky.KategoriGetir(), "Id", "Baslik");
            return View();
        }
          
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Not not)
        {
            ModelState.Remove("KayitTarihi");
            ModelState.Remove("DegistirmeTarihi");
            ModelState.Remove("DegistirenKullanici");

            ViewBag.KategoriId = new SelectList(ky.KategoriGetir(), "Id", "Baslik", not.KategoriId);

            if (ModelState.IsValid)
            {
                not.Kullanici =(Kullanici)Session["login"];

                 BusinessLayerResult<Not> sonuc= my.NotKaydet(not);

                if (sonuc.hata.Count > 0)
                {
                    sonuc.hata.ForEach(x => ModelState.AddModelError("", x));
                    return View(not);
                }

                return RedirectToAction("Index");
            }

          
            return View(not);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = my.NotBul(id.Value);
            if (not == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(ky.KategoriGetir(), "Id", "Baslik", not.KategoriId);
            return View(not);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Not not)
        {
            ModelState.Remove("KayitTarihi");
            ModelState.Remove("DegistirmeTarihi");
            ModelState.Remove("DegistirenKullanici");

            ViewBag.KategoriId = new SelectList(ky.KategoriGetir(), "Id", "Baslik", not.KategoriId);

            if (ModelState.IsValid)
            {
                not.Kullanici = (Kullanici)Session["login"];

                BusinessLayerResult<Not> sonuc = my.NotUpdate(not);

                if (sonuc.hata.Count > 0)
                {
                    sonuc.hata.ForEach(x => ModelState.AddModelError("", x));
                    return View(not);
                }                             

                return RedirectToAction("Index");
            }
          
            return View(not);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = my.NotBul(id.Value);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           BusinessLayerResult<Not> sonuc= my.NotSil(id);

           return RedirectToAction("Index");
        }

    }
}
