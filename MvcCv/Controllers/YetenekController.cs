using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        GenericRepositories<TBL_YETENEK> repo = new GenericRepositories<TBL_YETENEK>();
        // GET: Yetenek
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TBL_YETENEK p)
        {
            repo.TAdd(p);
            TempData["msg"] = "<script>alert('Yeni Yetenek Başarıyla Eklenmiştir.');</script>";
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=>x.ID==id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index","Yetenek");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var ytnk = repo.Find(x => x.ID == id);
            return View(ytnk);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TBL_YETENEK p)
        {
            if (p != null)
            {
               
            TBL_YETENEK t = repo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            t.oran = p.oran;
            repo.TUptade(t);
            TempData["msg"] =  "<script>alert('Yetenek Başarıyla Düzenlenmiştir.');</script>";
            return RedirectToAction("Index");
             
            }

            return View();
        }
    }
}