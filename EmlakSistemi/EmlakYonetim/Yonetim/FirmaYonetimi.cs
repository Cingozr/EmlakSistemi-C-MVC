using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class FirmaYonetimi 
    {
        [StringLength(50)]
        [Display(Name ="Firma Adı")]
        public string Firma_TAMAD { get; set; }
        [Display(Name = "Parola Giriniz:")]
        public string Firma_PAROLA { get; set; }
        [Display(Name = "Firma E-Mail")]
        public string Firma_EMAIL { get; set; }
        [Display(Name = "Gizli Sorunuz")]
        public string Gizli_SORU { get; set; }
        [Display(Name = "Gizli Cevap")]
        public string Gizli_CEVAP { get; set; }
    }
}