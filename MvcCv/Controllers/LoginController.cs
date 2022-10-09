﻿using MvcCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TBL_ADMİN p)
        {
            DbCVEntities db = new DbCVEntities();
            var bilgi = db.TBL_ADMİN.FirstOrDefault(x=>x.KullaniciAdi==p.KullaniciAdi && x.Sifre==p.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index","Deneyim");
            }

            else
            {
                TempData["msg"] = "Kullanıcı Adınız veya Şifreniz Hatalı!";
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Default");
        }
    }
}