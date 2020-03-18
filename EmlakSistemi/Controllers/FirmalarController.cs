using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.Controllers
{
    public class FirmalarController : Controller
    {
        // GET: Firmalar
        private readonly EmlakContext baglanti = new EmlakContext();
        public ActionResult Index()
        {
            return View(baglanti.aspnet_Users.ToList());
        }

        public ActionResult Firma()
        {
            return View();
        }

        public ActionResult FirmaProfil()
        {
            return RedirectToAction("Index", "Anasayfa", new { area = "FirmaPanel" });
        }
    }
}