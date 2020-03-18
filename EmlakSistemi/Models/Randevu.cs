namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Randevu")]
    public partial class Randevu
    {
        [Key]
        public int Randevu_ID { get; set; }

        [StringLength(50)]
        public string Randevu_BASLIK { get; set; }

        [StringLength(50)]
        public string Randevu_ACIKLAMA { get; set; }

        public DateTime? Randevu_TARIHBAS { get; set; }

        [StringLength(50)]
        public string Randevu_KISI { get; set; }

        public bool? Randevu_AKTIF { get; set; }

        public DateTime? Randevu_TARIHBIT { get; set; }

        public Guid? UserId { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}
