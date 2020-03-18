namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lokasyon")]
    public partial class Lokasyon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lokasyon()
        {
            Ilanlar = new HashSet<Ilanlar>();
        }

        [Key]
        public int Lokasyon_ID { get; set; }

        [StringLength(50)]
        public string Lokasyon_AD { get; set; }

        public double? Lokasyon_ENLEM { get; set; }

        public double? Lokasyon_BOYLAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilanlar> Ilanlar { get; set; }
    }
}
