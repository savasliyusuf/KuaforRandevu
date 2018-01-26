using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using joseph.Models;

namespace joseph.Controllers
{
    public class UyeRandevuController : Controller
    {
        KDB db = new KDB();

        // GET: UyeRandevu
        public ActionResult Index()
        {
            var randevus = db.Randevus.Include(r => r.Calisan).Include(r => r.Saat);
            return View(randevus.ToList());
        }

        

        // GET: UyeRandevu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Randevu randevu = db.Randevus.Find(id);
            if (randevu == null)
            {
                return HttpNotFound();
            }
            return View(randevu);
        }
        public ActionResult Details2()
        {
            var id = Convert.ToInt32(Session["üyeid"]);
            var randevus = db.Randevus.Include(r => r.Calisan).Include(r => r.Saat).Where(r => r.MusteriNo==id);
            if (randevus == null)
            {
                return HttpNotFound();
            }
            return View(randevus.ToList().First());
        }

        // GET: UyeRandevu/Create
        public ActionResult Create()
        {

            ViewBag.CalisanNo = new SelectList(db.Calisans, "CalisanNo", "Adi");
            //ViewBag.MusteriNo = new SelectList(db.Musteris, "MusteriNo", "Adi");
            ViewBag.SaatID = new SelectList(db.Saats, "SaatID", "Adi");
            return View();
        }

        // POST: UyeRandevu/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RandevuID,CalisanNo,Tarih,SaatID")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                randevu.MusteriNo = Convert.ToInt32(Session["üyeid"]);
                db.Randevus.Add(randevu);
                db.SaveChanges();
                return RedirectToAction("Details2");
            }

            ViewBag.CalisanNo = new SelectList(db.Calisans, "CalisanNo", "Adi", randevu.CalisanNo);
           // ViewBag.MusteriNo = new SelectList(db.Musteris, "MusteriNo", "Adi", randevu.MusteriNo);
            ViewBag.SaatID = new SelectList(db.Saats, "SaatID", "Adi", randevu.SaatID);
            return View(randevu);
        }

        // GET: UyeRandevu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Randevu randevu = db.Randevus.Find(id);
            if (randevu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CalisanNo = new SelectList(db.Calisans, "CalisanNo", "Adi", randevu.CalisanNo);
            ViewBag.MusteriNo = new SelectList(db.Musteris, "MusteriNo", "Adi", randevu.MusteriNo);
            ViewBag.SaatID = new SelectList(db.Saats, "SaatID", "Adi", randevu.SaatID);
            return View(randevu);
        }

        // POST: UyeRandevu/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RandevuID,MusteriNo,CalisanNo,Tarih,SaatID")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                randevu.MusteriNo = Convert.ToInt32(Session["üyeid"]);
                db.Entry(randevu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CalisanNo = new SelectList(db.Calisans, "CalisanNo", "Adi", randevu.CalisanNo);
            ViewBag.MusteriNo = new SelectList(db.Musteris, "MusteriNo", "Adi", randevu.MusteriNo);
            ViewBag.SaatID = new SelectList(db.Saats, "SaatID", "Adi", randevu.SaatID);
            return View(randevu);
        }

        // GET: UyeRandevu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Randevu randevu = db.Randevus.Find(id);
            if (randevu == null)
            {
                return HttpNotFound();
            }
            return View(randevu);
        }

        // POST: UyeRandevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Randevu randevu = db.Randevus.Find(id);
            db.Randevus.Remove(randevu);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
