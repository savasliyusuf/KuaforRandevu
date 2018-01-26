using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using joseph.Models;
namespace joseph.Controllers
{
    public class AdminCalisanController : Controller
    {
        KDB db = new KDB();
        // GET: AdminCalisan
        public ActionResult Index()
        {
            var calisans = db.Calisans.ToList();
            return View(calisans);
        }

        // GET: AdminCalisan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminCalisan/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: AdminCalisan/Create
        [HttpPost]
        public ActionResult Create(Calisan calisan)
        {
            try
            {
                db.Calisans.Add(calisan);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCalisan/Edit/5
        public ActionResult Edit(int id)
        {
            var calisan = db.Calisans.Where(m => m.CalisanNo == id).SingleOrDefault();
            if (calisan == null)
            {
                return HttpNotFound();
            }
            ViewBag.CalisanNo = new SelectList(db.Calisans, "CalisanNo", "Adı", calisan.CalisanNo);
            return View(calisan);
        }

        // POST: AdminCalisan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Calisan calisan)
        {
            try
            {
                var calisans = db.Calisans.Where(m => m.CalisanNo == id).SingleOrDefault();
                if (calisan != null)
                {
                    calisans.Adi = calisan.Adi;
                    calisans.Adres = calisan.Adres;
                    calisans.CalisanNo = calisan.CalisanNo;
                    calisans.Email = calisan.Email;
                    calisans.KullaniciAdi=calisan.KullaniciAdi;
                    calisans.Randevus = calisan.Randevus;
                    calisans.Sifre = calisan.Sifre;
                    calisans.Soyadi = calisan.Soyadi;
                    calisans.Telefon = calisan.Telefon;
                    calisans.Uzmanlik = calisan.Uzmanlik;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCalisan/Delete/5
        public ActionResult Delete(int id)
        {
            var calisan = db.Calisans.Where(m => m.CalisanNo == id).SingleOrDefault();
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        // POST: AdminCalisan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var calisan = db.Calisans.Where(m => m.CalisanNo == id).SingleOrDefault();
                if (calisan == null)
                {
                    return HttpNotFound();
                }
                foreach (var i in calisan.Randevus.ToList())
                {
                    db.Randevus.Remove(i);
                }
               
                db.Calisans.Remove(calisan);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
