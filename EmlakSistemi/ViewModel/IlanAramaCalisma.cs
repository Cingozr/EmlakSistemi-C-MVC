using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.ViewModel
{
    public class IlanAramaCalisma
    {
        private EmlakContext Baglanti;
        public IlanAramaCalisma()
        {
            Baglanti = new EmlakContext();
        }
        public IQueryable<Ilanlar> GetIlanlar(IlanAramaModel AramaModel)
        {
            var sonuc = Baglanti.Ilanlar.AsQueryable();
            if (AramaModel != null)
            {
                if (AramaModel.Ilan_NO.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Ilan_NO == AramaModel.Ilan_NO);
                }

                if (!string.IsNullOrEmpty(AramaModel.Ilan_AD))
                {
                    sonuc = sonuc.Where(x => x.Ilan_AD.Contains(AramaModel.Ilan_AD));
                }

                if (AramaModel.Kategori_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.AnaKategori.AltKategori.Kategoriler.Kategori_ID == AramaModel.Kategori_ID);
                }
                if (AramaModel.AltKategori_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.AnaKategori.AltKategori_ID == AramaModel.AltKategori_ID);
                }
                if (AramaModel.AnaKategori_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.AnaKategori_ID == AramaModel.AnaKategori_ID);
                }

                if (AramaModel.Ilce_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Mahalle.Ilce_ID == AramaModel.Ilce_ID);
                }
                if (AramaModel.Il_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Mahalle.ilceler.Il_ID == AramaModel.Il_ID);
                }
                if (AramaModel.Mahalle_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Mahalle_ID == AramaModel.Mahalle_ID);
                }

                if (AramaModel.Ilan_FIYAT_BASLANGIC.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Ilan_FIYAT >= AramaModel.Ilan_FIYAT_BASLANGIC);
                }

                if (AramaModel.Ilan_FIYAT_BITIS.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Ilan_FIYAT <= AramaModel.Ilan_FIYAT_BITIS);
                }

                if (AramaModel.Ilan_METREKARE_BASLANGIC.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Ilan_METREKARE >= AramaModel.Ilan_METREKARE_BASLANGIC);
                }
                if (AramaModel.Ilan_METREKARE_BITIS.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Ilan_METREKARE <= AramaModel.Ilan_METREKARE_BITIS);
                }
                if (AramaModel.Isıtma_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Isıtma_ID == AramaModel.Isıtma_ID);
                }
                if (AramaModel.Kat_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Kat_ID == AramaModel.Kat_ID);
                }

                if (AramaModel.BinaYas_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.BinaYas_ID == AramaModel.BinaYas_ID);
                }
                if (AramaModel.Oda_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Oda_ID == AramaModel.Oda_ID);
                }
                if (AramaModel.KullanimDurum_ID.HasValue)
                {
                    sonuc = sonuc.Where(x => x.KullanimDurum_ID == AramaModel.KullanimDurum_ID);
                }
                if (AramaModel.Ilan_TARIHI.HasValue)
                {
                    sonuc = sonuc.Where(x => x.Ilan_TARIHI == AramaModel.Ilan_TARIHI);
                }
            }
            return sonuc;
        }
    }
}