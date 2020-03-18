namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnaKategori")]
    public partial class AnaKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnaKategori()
        {
            Ilanlar = new HashSet<Ilanlar>();
        }

        [Key]
        public int AnaKategori_ID { get; set; }

        [StringLength(50)]
        public string AnaKategori_AD { get; set; }

        public int? AltKategori_ID { get; set; }

        public virtual AltKategori AltKategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilanlar> Ilanlar { get; set; }
    }
}
