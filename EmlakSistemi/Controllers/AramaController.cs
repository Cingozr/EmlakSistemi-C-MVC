using EmlakSistemi.Models;
using EmlakSistemi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.Controllers
{
    public class AramaController : Controller
    {
        // GET: Arama
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AramaSecenekleri()
        {
            EmlakContext baglanti = new EmlakContext();
            IlanAramaModel model = new IlanAramaModel();
            List<KatBilgisi> Katliste = baglanti.KatBilgisi.OrderBy(s => s.Kat_AD).ToList();
            model.Katlistesi = (from s in Katliste
                               select new SelectListItem
                               {
                                   Text = s.Kat_AD,
                                   Value = s.Kat_ID.ToString()

                               }).ToList();
            model.Katlistesi.Insert(0, new SelectListItem { Value = "", Text = "Kat Seçiniz", Selected = true });

            List<OdaBilgisi> OdaListe = baglanti.OdaBilgisi.OrderBy(s => s.Oda_AD).ToList();
            model.OdaListesi = (from s in OdaListe
                                select new SelectListItem
                                {
                                    Text = s.Oda_AD,
                                    Value = s.Oda_ID.ToString()

                                }).ToList();
            model.OdaListesi.Insert(0, new SelectListItem { Value = "", Text = "Oda Sayısı Seçiniz", Selected = true });

            List<IsıtmaBilgisi> IsitmaListe = baglanti.IsıtmaBilgisi.OrderBy(s => s.Isıtma_AD).ToList();
            model.IsitmaListesi = (from s in IsitmaListe
                                   select new SelectListItem
                                   {
                                       Text = s.Isıtma_AD,
                                       Value = s.Isıtma_ID.ToString()

                                   }).ToList();
            model.IsitmaListesi.Insert(0, new SelectListItem { Value = "", Text = "Isıtma Seçiniz", Selected = true });

            List<BinaYasBilgisi> BinayasListe = baglanti.BinaYasBilgisi.OrderBy(s => s.BinaYas_AD).ToList();
            model.BinaYasListesi = (from s in BinayasListe
                                   select new SelectListItem
                                   {
                                       Text = s.BinaYas_AD,
                                       Value = s.BinaYas_ID.ToString()

                                   }).ToList();
            model.BinaYasListesi.Insert(0, new SelectListItem { Value = "", Text = "Bina Yaşı Seçiniz", Selected = true });

            List<DurumBilgisi> DurumListe = baglanti.DurumBilgisi.OrderBy(s => s.KullanimDurum_AD).ToList();
            model.KullanimDurumListe = (from s in DurumListe
                                    select new SelectListItem
                                    {
                                        Text = s.KullanimDurum_AD,
                                        Value = s.KullanimDurum_ID.ToString()

                                    }).ToList();
            model.KullanimDurumListe.Insert(0, new SelectListItem { Value = "", Text = "Kullanım Durumu Seçiniz", Selected = true });
            return View(model);
        }
       
    }
}