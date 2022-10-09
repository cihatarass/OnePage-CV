using MvcCv.Models;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class İletisimController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        GenericRepositories<TBL_İLETİSİM> repo = new GenericRepositories<TBL_İLETİSİM>();
        // GET: İletisim
        public ActionResult Index()
        {

            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}