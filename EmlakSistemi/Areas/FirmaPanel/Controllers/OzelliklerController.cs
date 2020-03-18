using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmlakSistemi.Models;

namespace EmlakSistemi.Areas.FirmaPanel.Controllers
{
    public class OzelliklerController : Controller
    {
        // GET: FirmaPanel/Ozellikler
        private readonly EmlakContext baglanti = new EmlakContext();
        public ActionResult Index()
        {
            ViewBag.Isitma = baglanti.IsıtmaBilgisi.ToList();
            ViewBag.Kat = baglanti.KatBilgisi.ToList();
            ViewBag.Oda = baglanti.OdaBilgisi.ToList();
            ViewBag.Yas = baglanti.BinaYasBilgisi.ToList();
            ViewBag.Cephe = baglanti.Cephe.ToList();
            ViewBag.DisOzellik = baglanti.DisOzellik.ToList();
            ViewBag.IcOzellik = baglanti.IcOzellik.ToList();
            ViewBag.Engelli = baglanti.EngelliUygunluk.ToList();
            ViewBag.Muhit = baglanti.Muhit.ToList();
            ViewBag.Ulasim = baglanti.Ulasim.ToList();
            ViewBag.Manzara = baglanti.Manzara.ToList();

            return View();
        }

        #region Isıtma Bilgisi
        public ActionResult IsitmaBilgisi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IsitmaBilgisi(IsıtmaBilgisi IsitmaModel)
        {
            baglanti.IsıtmaBilgisi.Add(IsitmaModel);
            baglanti.SaveChanges();
            return RedirectToAction("Index","Ozellikler");
        }
        #endregion

        #region Kat Bilgisi
        public ActionResult KatBilgisi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KatBilgisi(KatBilgisi KatModel)
        {
            baglanti.KatBilgisi.Add(KatModel);
            baglanti.SaveChanges();
            return RedirectToAction("Index", "Ozellikler");
        }
        #endregion

        #region Oda Bilgisi
        public ActionResult OdaBilgisi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OdaBilgisi(OdaBilgisi OdaModel)
        {
            baglanti.OdaBilgisi.Add(OdaModel);
            baglanti.SaveChanges();
            return RedirectToAction("Index", "Ozellikler");
        }
        #endregion

        #region Yas Bilgisi
        public ActionResult YasBilgisi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YasBilgisi(BinaYasBilgisi YasModel)
        {
            baglanti.BinaYasBilgisi.Add(YasModel);
            baglanti.SaveChanges();
            return RedirectToAction("Index", "Ozellikler");
        }
        #endregion

        #region Cephe Bilgisi
        public ActionResult CepheBilgisi()
        {
            return View(baglanti.Cephe.ToList());
        }
        [HttpPost]
        public ActionResult CepheBilgisi(Cephe cepheModel)
        {
            baglanti.Cephe.Add(cepheModel);
            baglanti.SaveChanges();
            return View();
        }
        #endregion

        #region Dış Özellik Bilgisi
        public ActionResult DisOzellikBilgisi()
        {
            return View(baglanti.DisOzellik.ToList());
        }
        [HttpPost]
        public ActionResult DisOzellikBilgisi(DisOzellik DisOzellikheModel)
        {
            baglanti.DisOzellik.Add(DisOzellikheModel);
            baglanti.SaveChanges();
            return View();
        }
        #endregion

        #region İç Özellik Bilgisi
        public ActionResult IcOzellikBilgisi()
        {
            return View(baglanti.IcOzellik.ToList());
        }
        [HttpPost]
        public ActionResult IcOzellikBilgisi(IcOzellik IcOzellikheModel)
        {
            baglanti.IcOzellik.Add(IcOzellikheModel);
            baglanti.SaveChanges();
            return View();
        }
        #endregion

        #region Engelli Bilgisi
        public ActionResult EngelliBilgisi()
        {
            return View(baglanti.EngelliUygunluk.ToList());
        }
        [HttpPost]
        public ActionResult EngelliBilgisi(EngelliUygunluk EngelliModel)
        {
            baglanti.EngelliUygunluk.Add(EngelliModel);
            baglanti.SaveChanges();
            return View();
        }
        #endregion

        #region Muhit Bilgisi
        public ActionResult MuhitBilgisi()
        {
            return View(baglanti.Muhit.ToList());
        }
        [HttpPost]
        public ActionResult MuhitBilgisi(Muhit MuhitModel)
        {
            baglanti.Muhit.Add(MuhitModel);
            baglanti.SaveChanges();
            return View();
        }
        #endregion

        #region Ulaşım Bilgisi
        public ActionResult UlasimBilgisi()
        {
            return View(baglanti.Ulasim.ToList());
        }
        [HttpPost]
        public ActionResult UlasimBilgisi(Ulasim UlasimModel)
        {
            baglanti.Ulasim.Add(UlasimModel);
            baglanti.SaveChanges();
            return View();
        }
        #endregion

    }
}