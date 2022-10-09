using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        GenericRepositories<TBL_SERTİFİKA> repo = new GenericRepositories<TBL_SERTİFİKA>();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TBL_SERTİFİKA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID==id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TBL_SERTİFİKA p)
        {
            TBL_SERTİFİKA t = repo.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TUptade(t);
            return RedirectToAction("Index");
        }

       
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.ID==id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}