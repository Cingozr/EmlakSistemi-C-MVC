
using EmlakSistemi.EmlakYonetim.Yonetim;
using EmlakSistemi.Models;
using EmlakSistemi.ViewModel;
using EmlakSistemi.ViewModel.Ilan;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmlakSistemi.Controllers
{
    public class EmlakController : Controller
    {
        private EmlakContext baglanti = new EmlakContext();
       
        #region İndex
        public ActionResult Index()
        {
            
            return View();
        }
        #endregion 

        #region Arama
        public ActionResult Arama(IlanAramaModel ModelArama)
        {
            var ilanarama = new IlanAramaCalisma();
            var model = ilanarama.GetIlanlar(ModelArama);
            return View(ModelArama);
        }
        #endregion        

        #region AramaSonuc
        [HttpPost]
        public ActionResult IlanlarSonuc(IlanAramaModel ModelArama)
        {
            Kategoriler kat = new Kategoriler();
            

            var ilanarama = new IlanAramaCalisma();
            var model = ilanarama.GetIlanlar(ModelArama);
            return View(model.ToList());
        }
        #endregion

        #region İlan Ekleme Get
        public ActionResult IlanEkle()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                try
                {
                    ViewBag.BinaYas_ID = new SelectList(baglanti.BinaYasBilgisi, "BinaYas_ID", "BinaYas_AD").ToList();
                    ViewBag.KullanimDurum_ID = new SelectList(baglanti.DurumBilgisi, "KullanimDurum_ID", "KullanimDurum_AD").ToList();
                    ViewBag.Isıtma_ID = new SelectList(baglanti.IsıtmaBilgisi, "Isıtma_ID", "Isıtma_AD").ToList();
                    ViewBag.Kat_ID = new SelectList(baglanti.KatBilgisi, "Kat_ID", "Kat_AD").ToList();
                    ViewBag.Kategori_ID = new SelectList(baglanti.Kategoriler, "Kategori_ID", "Kategori_AD").ToList();
                    ViewBag.Mahalle_ID = new SelectList(baglanti.Mahalle, "Mahalle_ID", "Mahaller_AD").ToList();
                    ViewBag.Oda_ID = new SelectList(baglanti.OdaBilgisi, "Oda_ID", "Oda_AD").ToList();

                    IlanEkle model = new IlanEkle();
                    var tumıcOzellik = IcOzellikYonetim.GetAll();
                    var tumdisOzellik = DisOzellikYonetim.GetAll();
                    var tumCepheOzellik = CepheYonetim.GetAll();
                    var tumEngelliOzellik = EngelliUygunlukYonetim.GetAll();
                    var tumManzaraOzellik = ManzaraYonetim.GetAll();
                    var tumMuhitOzellik = MuhitYonetim.GetAll();
                    var tumUlasimOzellik = UlasimYonetim.GetAll();

                    var checkboxlistitemIC = new List<CheckBoxListItem>();
                    var checkboxlistitemDIS = new List<CheckBoxListItem>();
                    var checkboxlistitemCEPHE = new List<CheckBoxListItem>();
                    var checkboxlistitemENGELLI = new List<CheckBoxListItem>();
                    var checkboxlistitemMANZARA = new List<CheckBoxListItem>();
                    var checkboxlistitemMUHIT = new List<CheckBoxListItem>();
                    var checkboxlistitemULASIM = new List<CheckBoxListItem>();

                    foreach (var icozellik in tumıcOzellik)
                    {
                        checkboxlistitemIC.Add(new CheckBoxListItem()
                        {
                            ID = icozellik.IcOzellik_ID,
                            Display = icozellik.IcOzellik_AD,
                            IsChecked = false
                        });
                    }

                    foreach (var disozellik in tumdisOzellik)
                    {
                        checkboxlistitemDIS.Add(new CheckBoxListItem()
                        {
                            ID = disozellik.DisOzellik_ID,
                            Display = disozellik.DisOzellik_AD,
                            IsChecked = false
                        });
                    }

                    foreach (var cepheozellik in tumCepheOzellik)
                    {
                        checkboxlistitemCEPHE.Add(new CheckBoxListItem()
                        {
                            ID = cepheozellik.Cephe_ID,
                            Display = cepheozellik.Cephe_AD,
                            IsChecked = false
                        });
                    }

                    foreach (var engelliozellik in tumEngelliOzellik)
                    {
                        checkboxlistitemENGELLI.Add(new CheckBoxListItem()
                        {
                            ID = engelliozellik.EngelliUygunluk_ID,
                            Display = engelliozellik.EngelliUygunluk_AD,
                            IsChecked = false
                        });
                    }

                    foreach (var manzaraozellik in tumManzaraOzellik)
                    {
                        checkboxlistitemMANZARA.Add(new CheckBoxListItem()
                        {
                            ID = manzaraozellik.Manzara_ID,
                            Display = manzaraozellik.Manzara_AD,
                            IsChecked = false
                        });
                    }

                    foreach (var muhitozellik in tumMuhitOzellik)
                    {
                        checkboxlistitemMUHIT.Add(new CheckBoxListItem()
                        {
                            ID = muhitozellik.Muhit_ID,
                            Display = muhitozellik.Muhit_AD,
                            IsChecked = false
                        });
                    }

                    foreach (var ulasimozellik in tumUlasimOzellik)
                    {
                        checkboxlistitemULASIM.Add(new CheckBoxListItem()
                        {
                            ID = ulasimozellik.Ulasim_ID,
                            Display = ulasimozellik.Ulasim_AD,
                            IsChecked = false
                        });
                    }

                    model.IcOzellik = checkboxlistitemIC;
                    model.DisOzellik = checkboxlistitemDIS;
                    model.Cephe = checkboxlistitemCEPHE;
                    model.Engelli = checkboxlistitemENGELLI;
                    model.Manzara = checkboxlistitemMANZARA;
                    model.Muhit = checkboxlistitemMUHIT;
                    model.Ulasim = checkboxlistitemULASIM;
                    var hepsi = model;

                    return View(hepsi);
                }
                catch (Exception ex)
                {

                    return View("Hata !", new HandleErrorInfo(ex, "IlanEkle", "Emlak"));
                }
            }
        }
        #endregion

        #region İlan Ekleme POST
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IlanEkle(IlanEkle model)
        {
            
            var IcOzellikSec = model.IcOzellik.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            var DisozellikSec = model.DisOzellik.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            var CepheSec = model.Cephe.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            var EngelliSec = model.Engelli.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            var ManzaraSec = model.Manzara.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            var MuhitSec = model.Muhit.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            var UlasimSec = model.Ulasim.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            IlanYonetimi.Add(
                model.Ilan_NO,
                model.UserId,
                model.Ilan_AD,
                model.AnaKategori_ID,
                model.Ilan_ACIKLAMA,
                model.Ilan_FIYAT,
                model.Ilan_AIDAT,
                model.Lokasyon_ID,
                model.Ilan_METREKARE,
                model.Mahalle_ID,
                model.Kat_ID,
                model.BinaYas_ID,
                model.KullanimDurum_ID,
                model.Oda_ID,
                model.Isıtma_ID,
                model.Ilan_ESYADURUM,
                model.Ilan_KRKEDIDURUM,
                model.Vitrin,
                IcOzellikSec,
                DisozellikSec,
                CepheSec,
                EngelliSec,
                ManzaraSec,
                MuhitSec,
                UlasimSec);
            return RedirectToAction("Index", "Emlak");
        }
        #endregion

        #region İlanlar Listesi
        public ActionResult Ilanlar(int? SayfaNo)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                int _SayfaNo = SayfaNo ?? 1;
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
                    .Include(i => i.OdaBilgisi).OrderByDescending(i => i.Ilan_ID).ToPagedList(_SayfaNo, 10);
                return View(ilanlar);
            }
        }
        #endregion

        #region İlan Detay Sayfası
        public ActionResult IlanDetay(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                var ilanlar = baglanti.Ilanlar.Where(x => x.Ilan_ID == id)
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
                    .Include(i=>i.Cephe)
                    .Include(i => i.IcOzellik)
                    .Include(i => i.DisOzellik)
                    .Include(i => i.EngelliUygunluk)
                    .Include(i => i.Manzara)
                    .Include(i => i.Muhit)
                    .Include(i => i.Ulasim)
                    .Include(i => i.Mahalle.ilceler.iller).OrderByDescending(i => i.Ilan_ID).FirstOrDefault();
                //var Ilanlar = IlanYonetimi.Detay(ilanlar.Ilan_ID);
                //ViewBag.cepheozellik = baglanti.Cephe.FirstOrDefault(x => x.Cephe_ID == ilanlar.Ilan_ID);


                if (ilanlar == null)
                {
                    return HttpNotFound();
                }
                return View(ilanlar);
            }

        }
        #endregion

        #region Adres Listesi - İL
        public ActionResult AdresListe()
        {
            EmlakContext baglanti = new EmlakContext();
            SehirModel model = new SehirModel();
            List<iller> Illiste = baglanti.iller.OrderBy(s => s.Il_AD).ToList();
            model.SehirList = (from s in Illiste
                               select new SelectListItem
                               {
                                   Text = s.Il_AD,
                                   Value = s.Il_ID.ToString()

                               }).ToList();
            model.SehirList.Insert(0, new SelectListItem { Value = "", Text = "İl Seçiniz", Selected = true });
            return View(model);
        }
        #endregion

        #region Adres Listesi - İLÇE
        [HttpPost]
        public JsonResult IlceList(int id)
        {
            EmlakContext baglanti = new EmlakContext();
            List<ilceler> IlceList = baglanti.ilceler.Where(i => i.Il_ID == id).OrderBy(i => i.Ilce_AD).ToList();

            List<SelectListItem> ItemList = (from i in IlceList
                                             select new SelectListItem
                                             {
                                                 Value = i.Ilce_ID.ToString(),
                                                 Text = i.Ilce_AD

                                             }).ToList();
            return Json(ItemList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Adres Listesi - MAHALLE
        [HttpPost]
        public JsonResult SemtList(int id)
        {
            EmlakContext baglanti = new EmlakContext();
            List<Mahalle> MahalleList = baglanti.Mahalle.Where(m => m.Ilce_ID == id).OrderBy(m => m.Mahaller_AD).ToList();

            List<SelectListItem> ItemList = (from m in MahalleList
                                             select new SelectListItem
                                             {
                                                 Value = m.Mahalle_ID.ToString(),
                                                 Text = m.Mahaller_AD

                                             }).ToList();
            return Json(ItemList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Kategori Listesi - İlk Kategori
        public ActionResult KategoriListesi()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                KategoriModel KategoriM = new KategoriModel();
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
        #endregion

        #region Kategori Listesi - İkinci Kategori
        [HttpPost]
        public JsonResult AltKatList(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                List<AltKategori> AltKategoriList = baglanti.AltKategori.Where(
                    ak => ak.Kategori_ID == id).OrderBy(ak => ak.AltKategori_AD).ToList();
                List<SelectListItem> AKList = (from i in AltKategoriList
                                               select new SelectListItem
                                               {
                                                   Value = i.AltKategori_ID.ToString(),
                                                   Text = i.AltKategori_AD
                                               }).ToList();
                return Json(AKList, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Kategori Listesi - Ana Kategori
        [HttpPost]
        public JsonResult AnaKatList(int id)
        {
            EmlakContext baglanti = new EmlakContext();
            List<AnaKategori> AnaKatListe = baglanti.AnaKategori.Where(m => m.AltKategori_ID == id).OrderBy(m => m.AnaKategori_AD).ToList();

            List<SelectListItem> ItemList = (from m in AnaKatListe
                                             select new SelectListItem
                                             {
                                                 Value = m.AnaKategori_ID.ToString(),
                                                 Text = m.AnaKategori_AD

                                             }).ToList();
            return Json(ItemList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Mesaj Gonder Get
        public ActionResult MesajGonder()
        {
            return View();
        }
        #endregion

        #region Mesaj Gonder POST
        [HttpPost]
        public ActionResult MesajGonder(Mesaj MsjModel, string firmaid)
        {
            //var  kullanici = baglanti.Ilanlar.Where(x => x.UserId==firmaid);

            Mesaj Mesaj = new Mesaj();
            Mesaj.Mesaj_BASLIK = MsjModel.Mesaj_BASLIK;
            Mesaj.Mesaj_AD = MsjModel.Mesaj_AD;
            Mesaj.Mesaj_SOYAD = MsjModel.Mesaj_SOYAD;
            Mesaj.Mesaj_TEL = MsjModel.Mesaj_TEL;
            Mesaj.Mesaj_TARIH = DateTime.Now.ToLocalTime();
            Mesaj.Mesaj_ACIKLAMA = MsjModel.Mesaj_ACIKLAMA;
            //Mesaj.UserId = new Guid(kullanici);
            baglanti.Mesaj.Add(Mesaj);
            baglanti.SaveChanges();
            return RedirectToAction("Index","Anasayfa");
        }
        #endregion

        #region Firmanın Diğer İlanları
        public ActionResult DigerIlanlar()
        {
           
            List<Ilanlar> Firmaliste = baglanti.Ilanlar.Where(i => i.UserId == (Guid)Membership.GetUser().ProviderUserKey)
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
                    .Include(i => i.OdaBilgisi).ToList();
            return View(Firmaliste);
        }
        #endregion




    }
}