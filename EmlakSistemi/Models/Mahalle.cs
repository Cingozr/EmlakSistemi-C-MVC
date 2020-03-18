namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mahalle")]
    public partial class Mahalle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mahalle()
        {
            Ilanlar = new HashSet<Ilanlar>();
        }

        [Key]
        public int Mahalle_ID { get; set; }

        [StringLength(50)]
        public string Mahaller_AD { get; set; }

        public int? Ilce_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilanlar> Ilanlar { get; set; }

        public virtual ilceler ilceler { get; set; }
    }
}
