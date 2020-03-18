using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.ViewModel
{
    public class IlanAramaModel
    {
        public IlanAramaModel()
        {
            SehirList = new List<SelectListItem>();
            SehirList.Add(new SelectListItem { Text = "İl Seçiniz", Value = "" });
            IlceList = new List<SelectListItem>();
            IlceList.Add(new SelectListItem { Text = "İlçe Seçiniz", Value = "" });
            MahalleList = new List<SelectListItem>();
            MahalleList.Add(new SelectListItem { Text = " Semt / Mahalle Seçiniz", Value = "" });

            IlkKategori = new List<SelectListItem>();
            IlkKategori.Add(new SelectListItem { Text = "Emlak Tipi", Value = "" });
            IkinciKategori = new List<SelectListItem>();
            IkinciKategori.Add(new SelectListItem { Text = "Durum Seçiniz", Value = "" });
            AnaKategori = new List<SelectListItem>();
            AnaKategori.Add(new SelectListItem { Text = "Tür Seçiniz", Value = "" });
           

        }
        public int? Ilan_NO { get; set; }       
        public string Ilan_AD { get; set; }
        public int? Kategori_ID { get; set; }
        public int? AltKategori_ID { get; set; }
        public int? AnaKategori_ID { get; set; }
        public decimal? Ilan_FIYAT_BASLANGIC { get; set; }
        public decimal? Ilan_FIYAT_BITIS { get; set; }
        public int? Ilan_METREKARE_BASLANGIC { get; set; }
        public int? Ilan_METREKARE_BITIS { get; set; }
        public string Ilan_AIDAT { get; set; }
        public int? Lokasyon_ID { get; set; }
        public int? Il_ID { get; set; }
        public int? Ilce_ID { get; set; }
        public int? Mahalle_ID { get; set; }
        public int? Kat_ID { get; set; }
        public int? BinaYas_ID { get; set; }
        public int? KullanimDurum_ID { get; set; }
        public int? Oda_ID { get; set; }
        public int? Isıtma_ID { get; set; }
        public int? Medya_ID { get; set; }
        public int? IlanSahib_ID { get; set; }       
        public DateTime? Ilan_TARIHI { get; set; }



        public List<SelectListItem> OdaListesi { get; set; }
        public List<SelectListItem> Katlistesi { get; set; }
        public List<SelectListItem> IsitmaListesi { get; set; }
        public List<SelectListItem> BinaYasListesi { get; set; }
        public List<SelectListItem> KullanimDurumListe { get; set; }
        public List<SelectListItem> IlkKategori { get; set; }
        public List<SelectListItem> IkinciKategori { get; set; }
        public List<SelectListItem> AnaKategori { get; set; }
        public List<SelectListItem> SehirList { get; set; }
        public List<SelectListItem> IlceList { get; set; }
        public List<SelectListItem> MahalleList { get; set; }
    }
}