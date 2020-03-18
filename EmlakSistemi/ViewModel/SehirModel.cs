using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.ViewModel
{
    public class SehirModel
    {
        public SehirModel()
        {
            SehirList = new List<SelectListItem>();
            SehirList.Add(new SelectListItem { Text = "İl Seçiniz", Value = "" });
            IlceList = new List<SelectListItem>();
            IlceList.Add(new SelectListItem { Text = "İlçe Seçiniz", Value = "" });
            MahalleList = new List<SelectListItem>();
            MahalleList.Add(new SelectListItem { Text = " Semt / Mahalle Seçiniz", Value = "" });
        }

        public int Il_ID { get; set; }
        public int Ilce_ID { get; set; }
        public int Mahalle_ID { get; set; }
        public List<SelectListItem> SehirList { get; set; }
        public List<SelectListItem> IlceList { get; set; }
        public List<SelectListItem> MahalleList { get; set; }
    }
}