namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hatirlatma")]
    public partial class Hatirlatma
    {
        [Key]
        public int Hatirlatma_ID { get; set; }

        [StringLength(50)]
        public string Hatirlatma_BASLIK { get; set; }

        [StringLength(50)]
        public string Hatırlatma_KONU { get; set; }

        public DateTime? Hatırlatma_TARIH { get; set; }

        public bool? Hatırlatma_AKTIF { get; set; }
    }
}
