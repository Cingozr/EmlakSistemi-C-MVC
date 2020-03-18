namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        [Key]
        public int Mesaj_ID { get; set; }

        [StringLength(50)]
        public string Mesaj_BASLIK { get; set; }

        public string Mesaj_ACIKLAMA { get; set; }

        [StringLength(50)]
        public string Mesaj_TEL { get; set; }

        [StringLength(50)]
        public string Mesaj_AD { get; set; }

        [StringLength(50)]
        public string Mesaj_SOYAD { get; set; }

        public DateTime? Mesaj_TARIH { get; set; }

        public Guid? UserId { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}
