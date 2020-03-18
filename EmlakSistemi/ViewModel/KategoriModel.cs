using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.ViewModel
{
    public class KategoriModel
    {
        public KategoriModel()
        {
            IkinciKategori = new List<SelectListItem>();
            IkinciKategori.Add(new SelectListItem { Text = "Durum Seçiniz", Value = "" });
            AnaKategori = new List<SelectListItem>();
            AnaKategori.Add(new SelectListItem { Text = "Tür Seçiniz", Value = "" });

        }


        public int Kategori_ID { get; set; }
        public int AltKategori_ID { get; set; }
        public int AnaKategori_ID { get; set; }
        public List<SelectListItem> IlkKategori { get; set; }
        public List<SelectListItem> IkinciKategori { get; set; }
        public List<SelectListItem> AnaKategori { get; set; }


    }
}