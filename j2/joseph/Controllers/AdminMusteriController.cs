using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using joseph.Models;

namespace joseph.Controllers
{
    public class AdminMusteriController : Controller
    {
        KDB db = new KDB();
        // GET: AdminMüsteri
        public ActionResult Index()
        {
            var musteris = db.Musteris.ToList();
            return View(musteris);
        }

        // GET: AdminMüsteri/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminMüsteri/Create
        public ActionResult Create()
        {
            ViewBag.YetkiNo = new SelectList(db.Yetkis, "YetkiNo", "YetkiAdı");
            return View();
        }

        // POST: AdminMüsteri/Create  oluştura tıklandığında çalışacak kodlar
        [HttpPost]
        public ActionResult Create(Musteri musteri)
        {
            try
            {
                db.Musteris.Add(musteri);
                db.SaveChanges();

                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminMüsteri/Edit/5
        public ActionResult Edit(int id)
        {
            var müşteri = db.Musteris.Where(m => m.MusteriNo == id).SingleOrDefault();
            if (müşteri == null)
            {
                return HttpNotFound();
            }
            ViewBag.YetkiNo = new SelectList(db.Yetkis, "YetkiNo", "YetkiAdı", müşteri.YetkiNo);
            return View(müşteri);
        }

        // POST: AdminMüsteri/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Musteri müşteri)
        {
            try
            {
                var müşteris = db.Musteris.Where(m => m.MusteriNo == id).SingleOrDefault();
                if (müşteri != null)
                {
                    müşteris.KullaniciAdi = müşteri.KullaniciAdi;
                    müşteris.MusteriNo = müşteri.MusteriNo;
                    müşteris.Randevus = müşteri.Randevus;
                    müşteris.Sifre = müşteri.Sifre;
                    müşteris.Soyadi = müşteri.Soyadi;
                    müşteris.Telefon = müşteri.Telefon;
                    müşteris.YetkiNo = müşteri.YetkiNo;
                    müşteris.Adi = müşteri.Adi;
                    müşteris.Email = müşteri.Email;
                    müşteris.Adres = müşteri.Adres;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }




        }
            

        // GET: AdminMüsteri/Delete/5
        public ActionResult Delete(int id)
        {
            var müşteri = db.Musteris.Where(m => m.MusteriNo == id).SingleOrDefault();
            if (müşteri == null)
            {
                return HttpNotFound();
            }
            return View(müşteri);
        }

        // POST: AdminMüsteri/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var müşteri = db.Musteris.Where(m => m.MusteriNo == id).SingleOrDefault();
                if (müşteri == null)
                {
                    return HttpNotFound();
                }
                foreach(var i in müşteri.Randevus.ToList())
                {
                    db.Randevus.Remove(i);
                }
                
                db.Musteris.Remove(müşteri);
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
