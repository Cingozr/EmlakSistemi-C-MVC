using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmlakSistemi.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        private readonly EmlakContext baglanti = new EmlakContext();
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult IlanFirmaMesaj(aspnet_Users MsjModel)
        //{
        //    Mesaj msj = new Mesaj();
        //    Ilanlar ilanlar = new Ilanlar();
        //    msj.Firma_ID = (int)Membership.GetUser(ilanlar.UserId);
        //}
    }
}