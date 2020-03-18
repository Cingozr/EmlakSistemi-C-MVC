namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DurumBilgisi")]
    public partial class DurumBilgisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DurumBilgisi()
        {
            Ilanlar = new HashSet<Ilanlar>();
        }

        [Key]
        public int KullanimDurum_ID { get; set; }

        [StringLength(50)]
        public string KullanimDurum_AD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilanlar> Ilanlar { get; set; }
    }
}
