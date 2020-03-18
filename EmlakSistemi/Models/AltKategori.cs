namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AltKategori")]
    public partial class AltKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AltKategori()
        {
            AnaKategori = new HashSet<AnaKategori>();
        }

        [Key]
        public int AltKategori_ID { get; set; }

        [StringLength(50)]
        public string AltKategori_AD { get; set; }

        public int? Kategori_ID { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnaKategori> AnaKategori { get; set; }
    }
}
