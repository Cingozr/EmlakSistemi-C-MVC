namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KonutTipi")]
    public partial class KonutTipi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KonutTipi()
        {
            IlanKonutTip = new HashSet<IlanKonutTip>();
        }

        [Key]
        public int KonutTipi_ID { get; set; }

        [StringLength(50)]
        public string KonutTipi_AD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IlanKonutTip> IlanKonutTip { get; set; }
    }
}
