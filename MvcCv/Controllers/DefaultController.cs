using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.TBL_HAKKİMDA.ToList();
            return View(degerler);
        }

        public PartialViewResult SosyalM()
        {
            var sosyal = db.TBL_SOSYALM.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyal);
        }

        public PartialViewResult Deneyim()
        {
            var degerler = db.TBL_DENEYİM.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Egitim()
        {
            var degerler = db.TBL_EGİTİM.ToList();
            return PartialView(degerler);
        }

        public  PartialViewResult Yetenekler()
        {
            var degerler = db.TBL_YETENEK.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Hobiler()
        {
            var degerler = db.TBL_HOBİ.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Sertifikalar()
        {
            var degerler = db.TBL_SERTİFİKA.ToList();
            return PartialView(degerler);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(TBL_İLETİSİM t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_İLETİSİM.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}