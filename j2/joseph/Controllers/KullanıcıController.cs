using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using joseph.Models;
namespace joseph.Controllers
{
    public class KullanıcıController : Controller
    {
        KDB db = new KDB();
        // GET: Kullanıcı
        public ActionResult Index(int id)
        {
            var uye = db.Musteris.Where(m => m.MusteriNo == id).SingleOrDefault();
            if (Convert.ToInt32(Session["üyeid"]) != uye.MusteriNo)
            {
                return HttpNotFound();
            }
            return View(uye);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Musteri müşteri)
        {
            var login = db.Musteris.Where(m => m.KullaniciAdi == müşteri.KullaniciAdi).SingleOrDefault();
            if(login.KullaniciAdi == müşteri.KullaniciAdi && login.Sifre == müşteri.Sifre)
            {
                Session["üyeid"] = login.MusteriNo;
                Session["KullanıcıAdı"] = login.KullaniciAdi;
                Session["yetkiid"] = login.YetkiNo;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            Session["üyeid"] = null;
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Musteri müşteri)
        {
            if (ModelState.IsValid)
            {
                müşteri.YetkiNo = 2;
            
            
            db.Musteris.Add(müşteri);
            db.SaveChanges();
            Session["üyeid"] = müşteri.MusteriNo;
            Session["KullanıcıAdı"] = müşteri.KullaniciAdi;
            return RedirectToAction("Index", "Home");
        }
            return View(müşteri);
        }
        public ActionResult Edit(int id)
        {
            var uye = db.Musteris.Where(m => m.MusteriNo == id).SingleOrDefault();
            if (Convert.ToInt32(Session["üyeid"]) != uye.MusteriNo)
            {
                return HttpNotFound();
            }
            return View(uye);

        }
        [HttpPost]
        public ActionResult Edit(Musteri müşteri,int id)
        {
            if (ModelState.IsValid)
            {
                var müşteris = db.Musteris.Where(m => m.MusteriNo == id).SingleOrDefault();
                müşteris.Adi = müşteri.Adi;
                müşteris.Adres = müşteri.Adres;
                müşteris.Email = müşteri.Email;
                müşteris.KullaniciAdi = müşteri.KullaniciAdi;
                müşteris.Soyadi = müşteri.Soyadi;
                müşteris.Sifre = müşteri.Sifre;
                müşteris.Telefon = müşteri.Telefon;
                db.SaveChanges();
                Session["KullanıcıAdı"] = müşteri.KullaniciAdi;
                return RedirectToAction("Index", "Home",new { id = müşteris.MusteriNo });



            }
            return View();
        }
    }
}