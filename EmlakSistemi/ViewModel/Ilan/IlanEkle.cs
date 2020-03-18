using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.ViewModel.Ilan
{
    public class IlanEkle
    {
        public int Ilan_ID { get; set; }

        public int? Ilan_NO { get; set; }

        [StringLength(300)]
        public string Ilan_AD { get; set; }

        public int? AnaKategori_ID { get; set; }

        public string Ilan_ACIKLAMA { get; set; }

        [Column(TypeName = "money")]
        public decimal? Ilan_FIYAT { get; set; }

        [StringLength(50)]
        public string Ilan_AIDAT { get; set; }

        public int? Lokasyon_ID { get; set; }

        public int? Ilan_METREKARE { get; set; }

        public int? Mahalle_ID { get; set; }

        public int? Kat_ID { get; set; }

        public int? BinaYas_ID { get; set; }

        public int? KullanimDurum_ID { get; set; }

        public int? Oda_ID { get; set; }

        public int? Isıtma_ID { get; set; }
        public int? Medya_ID { get; set; }

        public int? IlanSahib_ID { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Ilan_TARIHI { get; set; }
        

        public bool? Ilan_ESYADURUM { get; set; }

        public bool? Ilan_KRKEDIDURUM { get; set; }
        

        public bool? Vitrin { get; set; }

        public int? Ilan_GORUNTULENME { get; set; }

        public List<CheckBoxListItem> IcOzellik { get; set; }
        public List<CheckBoxListItem> DisOzellik { get; set; }
        public List<CheckBoxListItem> Cephe { get; set; }
        public List<CheckBoxListItem> Engelli { get; set; }
        public List<CheckBoxListItem> Manzara { get; set; }
        public List<CheckBoxListItem> Muhit { get; set; }
        public List<CheckBoxListItem> Ulasim { get; set; }
        public List<SelectListItem>  Medya { get; set; }
        public Guid UserId { get; internal set; }

        public IlanEkle()
        {
            IcOzellik = new List<CheckBoxListItem>();
            DisOzellik = new List<CheckBoxListItem>();
            Cephe = new List<CheckBoxListItem>();
            Engelli = new List<CheckBoxListItem>();
            Manzara = new List<CheckBoxListItem>();
            Muhit = new List<CheckBoxListItem>();
            Ulasim = new List<CheckBoxListItem>();
            Medya = new List<SelectListItem>();
        }
    }
}