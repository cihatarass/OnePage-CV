using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        GenericRepositories<TBL_ADMİN> repo = new GenericRepositories<TBL_ADMİN>();
        // GET: Admin
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TBL_ADMİN p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            TBL_ADMİN t = repo.Find(x=>x.ID==id);
            return View(t);
        }


        [HttpPost]
        public ActionResult AdminGetir(TBL_ADMİN p)
        {
            TBL_ADMİN t = repo.Find(x=>x.ID==p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.TUptade(t);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            TBL_ADMİN t = repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}