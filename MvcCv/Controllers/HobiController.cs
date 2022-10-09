using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        HobiRepositories repo = new HobiRepositories();
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }

        [HttpPost]
        public ActionResult Index(TBL_HOBİ p)
        {
            var t = repo.Find(x=>x.ID==1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUptade(t);
            return RedirectToAction("Index");
        }
    }
}