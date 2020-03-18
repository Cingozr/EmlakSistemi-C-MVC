namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firmalar")]
    public partial class Firmalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Firmalar()
        {
            Satislar = new HashSet<Satislar>();
        }

        [Key]
        public int Firma_ID { get; set; }

        [StringLength(50)]
        public string Firma_AD { get; set; }

        [StringLength(50)]
        public string Firma_VERGIDAIRESI { get; set; }

        [StringLength(11)]
        public string Firma_VERGINO { get; set; }

        [StringLength(160)]
        public string Fırma_ADRES { get; set; }

        [StringLength(50)]
        public string Firma_SABITTEL { get; set; }

        public bool? Firma_AKTIF { get; set; }

        [StringLength(50)]
        public string Firma_RESIM { get; set; }

        public int? Firma_GORUNTULENME { get; set; }

        [StringLength(50)]
        public string Firma_PAROLA { get; set; }

        public int? FirmaTur_ID { get; set; }

        public Guid? UserId { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual FirmaTur FirmaTur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
