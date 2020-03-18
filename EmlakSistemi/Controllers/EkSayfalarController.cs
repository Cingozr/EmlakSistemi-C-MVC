using EmlakSistemi.Models;
using EmlakSistemi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EmlakSistemi.Controllers
{
    public class EkSayfalarController : Controller
    {
        // GET: EkSayfalar
        public ActionResult Index()
        {
            return View();
        }
        

        public PartialViewResult Header()
        {
            return PartialView();
        }

        public PartialViewResult Slider()
        {
            return PartialView();
            
        }

        public PartialViewResult SliderAlt()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                ViewBag.Konut = baglanti.Kategoriler.Where(x => x.Kategori_ID == 1).ToList();
                return PartialView();
            }
               
        }

        public PartialViewResult PopulerAnasayfa()
        {

            return PartialView();
        }

        public PartialViewResult HizliMenu()
        {
            return PartialView();
        }

        public ActionResult AnaSayfaIlanlar()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                
                var ilanlar = baglanti.Ilanlar
                    .Include(i => i.AnaKategori)
                    .Include(i => i.AnaKategori.AltKategori)
                    .Include(i => i.aspnet_Users)
                    .Include(i => i.BinaYasBilgisi)
                    .Include(i => i.DurumBilgisi)
                    .Include(i => i.IsıtmaBilgisi)
                    .Include(i => i.KatBilgisi)
                    .Include(i => i.Lokasyon)
                    .Include(i => i.Mahalle)
                    .Include(i => i.Mahalle.ilceler)
                    .Include(i => i.Mahalle.ilceler.iller)
                    .Include(i => i.OdaBilgisi).OrderByDescending(i => i.Ilan_ID).ToList();
                return View(ilanlar);
            }
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public ActionResult AnaSayfaArama()
        {
           
            using (EmlakContext baglanti = new EmlakContext())
            {
                ViewBag.ToplamIlan = baglanti.Ilanlar.ToList().Count();
                IlanAramaModel KategoriM = new IlanAramaModel();
                List<Kategoriler> KategoriListesi = baglanti.Kategoriler.OrderBy(k => k.Kategori_AD).ToList();

                KategoriM.IlkKategori = (from s in KategoriListesi
                                         select new SelectListItem
                                         {
                                             Text = s.Kategori_AD,
                                             Value = s.Kategori_ID.ToString()
                                         }).ToList();
                KategoriM.IlkKategori.Insert(0, new SelectListItem { Text = "Kategori Seçiniz", Value = "" });

                return View(KategoriM);
            }
        }
        [HttpPost]
        public JsonResult AltKatList(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                List<AltKategori> AltKategoriList = baglanti.AltKategori.Where(ak => ak.Kategori_ID == id).OrderBy(ak => ak.AltKategori_AD).ToList();
                List<SelectListItem> AKList = (from i in AltKategoriList
                                               select new SelectListItem
                                               {
                                                   Value = i.AltKategori_ID.ToString(),
                                                   Text = i.AltKategori_AD
                                               }).ToList();
                return Json(AKList, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PopulerIlanlar()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                ViewBag.Konut = baglanti.AnaKategori.OrderBy(x => x.AnaKategori_AD).ToList().Count();
                ViewBag.Konut = baglanti.AnaKategori.OrderBy(x => x.AnaKategori_AD).ToList().Count();
                return View();
            }
        }



    }
}