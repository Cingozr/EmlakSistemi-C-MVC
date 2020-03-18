namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Satislar")]
    public partial class Satislar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Satislar()
        {
            SatisDetay = new HashSet<SatisDetay>();
        }

        [Key]
        public int Satis_ID { get; set; }

        public int? Firma_ID { get; set; }

        public DateTime? Satis_TARIH { get; set; }

        public DateTime? Odeme_TARIH { get; set; }

        public DateTime? Teslimat_TARIH { get; set; }

        public int? Sozlesme_ID { get; set; }

        public virtual Firmalar Firmalar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }

        public virtual Sozlesmeler Sozlesmeler { get; set; }
    }
}
