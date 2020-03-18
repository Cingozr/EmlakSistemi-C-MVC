namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medya")]
    public partial class Medya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medya()
        {
            Ilanlar = new HashSet<Ilanlar>();
        }

        [Key]
        public int Medya_ID { get; set; }

        [StringLength(50)]
        public string Medya_AD { get; set; }

        [StringLength(50)]
        public string Medya_VIDEO { get; set; }

        [StringLength(50)]
        public string Medya_RESIM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilanlar> Ilanlar { get; set; }
    }
}
