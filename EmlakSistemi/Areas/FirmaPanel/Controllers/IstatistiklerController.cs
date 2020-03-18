using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.Areas.FirmaPanel.Controllers
{
    public class IstatistiklerController : Controller
    {
        // GET: FirmaPanel/Istatistikler
        private readonly EmlakContext baglanti = new EmlakContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kategoriler()
        {
            List<Ilanlar> ilanmodel = new List<Ilanlar>();
            
            return View(ilanmodel.ToList());

            
        }
    }
}