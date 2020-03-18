using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{

    public static class IlanYonetimi
    {

        public static List<Ilanlar> GetAll()
        {

             using (EmlakContext baglanti = new EmlakContext())
            {
                var Ilanlar = baglanti.Ilanlar
                    .Include(x => x.IcOzellik)
                    .Include(x => x.DisOzellik)
                    .Include(x=>x.Cephe)
                    .Include(x=>x.EngelliUygunluk)
                    .Include(x=>x.Manzara)
                    .Include(x=>x.Muhit)
                    .Include(x=>x.Ulasim)
                    .Include(x => x.Medya)
                    .OrderBy(x => x.Ilan_AD).ToList();
                return Ilanlar;
            }
            
        }

        public static Ilanlar GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                var Ilan = baglanti.Ilanlar
                    .Include(x => x.IcOzellik)
                    .Include(x => x.DisOzellik)
                    .Include(x => x.Cephe)
                    .Include(x => x.EngelliUygunluk)
                    .Include(x => x.Manzara)
                    .Include(x => x.Muhit)
                    .Include(x => x.Ulasim)
                    .Include(x=>x.Medya)
                    .Where(x => x.Ilan_ID == id).First();
                return Ilan;
            }
        }
        public static Ilanlar Detay(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                var Ilan = baglanti.Ilanlar
                    .Include(x => x.IcOzellik)
                    .Include(x => x.DisOzellik)
                    .Include(x => x.Cephe)
                    .Include(x => x.EngelliUygunluk)
                    .Include(x => x.Manzara)
                    .Include(x => x.Muhit)
                    .Include(x => x.Ulasim)
                    .Include(x => x.Medya)
                    .Where(x => x.Ilan_ID == id).First();
                return Ilan;
            }
        }

        public static void Duzenle(
            int? ılan_NO,
            string ılan_AD,
            int? anaKategori_ID,
            string ılan_ACIKLAMA,
            decimal? ılan_FIYAT,
            string ılan_AIDAT,
            int? lokasyon_ID,
            int? ılan_METREKARE,
            int? mahalle_ID,
            int? kat_ID, int?
            binaYas_ID, int?
            kullanimDurum_ID,

            int? oda_ID,
            int? ısıtma_ID,
            bool? ılan_ESYADURUM,
            bool? ılan_KRKEDIDURUM,
            bool? vitrin,
            List<int> ıcOzellikSec,
            List<int> disozellikSec,
            List<int> cepheSec,
            List<int> engelliSec,
            List<int> manzaraSec,
            List<int> muhitSec,
            List<int> ulasimSec)
        {


            using (EmlakContext baglanti = new EmlakContext())
            {

                var Ilan = new Ilanlar()
                {
                    Ilan_NO = ılan_NO,
                    Ilan_AD = ılan_AD,
                    AnaKategori_ID = anaKategori_ID,
                    Ilan_ACIKLAMA = ılan_ACIKLAMA,
                    Ilan_FIYAT = ılan_FIYAT,
                    Ilan_AIDAT = ılan_AIDAT,
                    Lokasyon_ID = lokasyon_ID,
                    Ilan_METREKARE = ılan_METREKARE,
                    Mahalle_ID = mahalle_ID,
                    Kat_ID = kat_ID,
                    BinaYas_ID = binaYas_ID,
                    KullanimDurum_ID = kullanimDurum_ID,
                    Oda_ID = oda_ID,
                    Isıtma_ID = ısıtma_ID,
                    Vitrin = vitrin,
                    Ilan_TARIHI = DateTime.Now.ToLocalTime()
                };
                foreach (var IcOzellikID in ıcOzellikSec)
                {
                    var Icozellik = baglanti.IcOzellik.Find(IcOzellikID);
                    Ilan.IcOzellik.Add(Icozellik);
                }
                foreach (var DisOzellikID in disozellikSec)
                {
                    var Disozellikler = baglanti.DisOzellik.Find(DisOzellikID);
                    Ilan.DisOzellik.Add(Disozellikler);
                }

                foreach (var cepheSecID in cepheSec)
                {
                    var cepheozellikler = baglanti.Cephe.Find(cepheSecID);
                    Ilan.Cephe.Add(cepheozellikler);
                }

                foreach (var engelliSecID in engelliSec)
                {
                    var engelliozellikler = baglanti.EngelliUygunluk.Find(engelliSecID);
                    Ilan.EngelliUygunluk.Add(engelliozellikler);
                }

                foreach (var manzaraSecID in manzaraSec)
                {
                    var manzaraozellikler = baglanti.Manzara.Find(manzaraSecID);
                    Ilan.Manzara.Add(manzaraozellikler);
                }

                foreach (var muhitSecID in muhitSec)
                {
                    var muhitozellikler = baglanti.Muhit.Find(muhitSecID);
                    Ilan.Muhit.Add(muhitozellikler);
                }

                foreach (var ulasimSecID in ulasimSec)
                {
                    var ulasimozellikler = baglanti.Ulasim.Find(ulasimSecID);
                    Ilan.Ulasim.Add(ulasimozellikler);
                }


                
                baglanti.SaveChanges();

            }
        }

        internal static void Add(
            int? ılan_NO,
            Guid userId,
            string ılan_AD,
            int? anaKategori_ID,
            string ılan_ACIKLAMA,
            decimal? ılan_FIYAT,
            string ılan_AIDAT,
            int? lokasyon_ID,
            int? ılan_METREKARE,
            int? mahalle_ID,
            int? kat_ID, 
            int? binaYas_ID, 
            int? kullanimDurum_ID,
            
            int? oda_ID,
            int? ısıtma_ID,
            bool? ılan_ESYADURUM,
            bool? ılan_KRKEDIDURUM,
            bool? vitrin,
            List<int> ıcOzellikSec,
            List<int> disozellikSec,
            List<int> cepheSec,
            List<int> engelliSec,
            List<int> manzaraSec,
            List<int> muhitSec,
            List<int> ulasimSec)
        {
            

            using (EmlakContext baglanti = new EmlakContext())
            {
                Random rastgele = new Random();

                ılan_NO = rastgele.Next(1, 999999999);
                Guid Kullanici = (Guid)Membership.GetUser().ProviderUserKey;

                var Ilan = new Ilanlar()
                {
                    Ilan_NO = ılan_NO,
                    UserId= Kullanici,
                    Ilan_AD = ılan_AD,
                    AnaKategori_ID = anaKategori_ID,
                    Ilan_ACIKLAMA = ılan_ACIKLAMA,
                    Ilan_FIYAT = ılan_FIYAT,
                    Ilan_AIDAT = ılan_AIDAT,
                    Lokasyon_ID = lokasyon_ID,
                    Ilan_METREKARE = ılan_METREKARE,
                    Mahalle_ID = mahalle_ID,
                    Kat_ID = kat_ID,
                    BinaYas_ID = binaYas_ID,
                    KullanimDurum_ID = kullanimDurum_ID,
                    Oda_ID = oda_ID,
                    Isıtma_ID = ısıtma_ID,
                    Vitrin=vitrin,
                    Ilan_TARIHI = DateTime.Now.ToLocalTime()
                };
                foreach (var IcOzellikID in ıcOzellikSec)
                {
                    var Icozellik = baglanti.IcOzellik.Find(IcOzellikID);
                    Ilan.IcOzellik.Add(Icozellik);
                }
                foreach (var DisOzellikID in disozellikSec)
                {
                    var Disozellikler = baglanti.DisOzellik.Find(DisOzellikID);
                    Ilan.DisOzellik.Add(Disozellikler);
                }

                foreach (var cepheSecID in cepheSec)
                {
                    var cepheozellikler = baglanti.Cephe.Find(cepheSecID);
                    Ilan.Cephe.Add(cepheozellikler);
                }

                foreach (var engelliSecID in engelliSec)
                {
                    var engelliozellikler = baglanti.EngelliUygunluk.Find(engelliSecID);
                    Ilan.EngelliUygunluk.Add(engelliozellikler);
                }

                foreach (var manzaraSecID in manzaraSec)
                {
                    var manzaraozellikler = baglanti.Manzara.Find(manzaraSecID);
                    Ilan.Manzara.Add(manzaraozellikler);
                }

                foreach (var muhitSecID in muhitSec)
                {
                    var muhitozellikler = baglanti.Muhit.Find(muhitSecID);
                    Ilan.Muhit.Add(muhitozellikler);
                }

                foreach (var ulasimSecID in ulasimSec)
                {
                    var ulasimozellikler = baglanti.Ulasim.Find(ulasimSecID);
                    Ilan.Ulasim.Add(ulasimozellikler);
                }



                baglanti.Ilanlar.Add(Ilan);
                baglanti.SaveChanges();
            }
        }

        public static void Sil(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                var Ilan = baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First();
                baglanti.Ilanlar.Remove(Ilan);
                baglanti.SaveChanges();
            }
        }

        internal static List<Ilanlar> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}