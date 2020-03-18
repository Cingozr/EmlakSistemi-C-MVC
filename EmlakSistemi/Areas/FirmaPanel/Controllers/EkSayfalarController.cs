using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.Areas.FirmaPanel.Controllers
{
    public class EkSayfalarController : Controller
    {
        // GET: FirmaPanel/EkSayfalar
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SideBar()
        {
            return PartialView();
        }
        public PartialViewResult Header()
        {
            return PartialView();
        }
    }
}