using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        GenericRepositories<TBL_SOSYALM> repo = new GenericRepositories<TBL_SOSYALM>();
        // GET: SosyalM
        public ActionResult Index()
        {
            var sosyal = repo.List();
            return View(sosyal);
        }

        [HttpGet]
        public ActionResult SosyalEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SosyalEkle(TBL_SOSYALM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SosyalGetir(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult SosyalGetir(TBL_SOSYALM p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Durum = true;
            t.Link = p.Link;
            repo.TUptade(t);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalSil(int id)
        {
            TBL_SOSYALM p = repo.Find(x => x.ID == id);
            p.Durum = false;
            repo.TUptade(p);
            return RedirectToAction("Index");
        }
    }
}