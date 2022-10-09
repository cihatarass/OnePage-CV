using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    
    public class DeneyimController : Controller
    {
        DeneyimRepositories repo = new DeneyimRepositories();
        // GET: Deneyim
        [Authorize]
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TBL_DENEYİM p)
        {
            repo.TAdd(p);
            TempData["msg"] = "<script>alert('Deneyim Başarıyla Eklenmiştir.');</script>";
            return RedirectToAction("Index", "Deneyim");
        }
        
        public ActionResult DeneyimSil(int id)
        {
            TBL_DENEYİM t = repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index","Deneyim");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBL_DENEYİM t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TBL_DENEYİM p)
        {
            TBL_DENEYİM t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TUptade(t);
            TempData["msg"] = "<script>alert('Deneyim Başarıyla Düzenlenmiştir.');</script>";
            return RedirectToAction("Index", "Deneyim");
        }
    }
}