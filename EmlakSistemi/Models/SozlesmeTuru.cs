namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SozlesmeTuru")]
    public partial class SozlesmeTuru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SozlesmeTuru()
        {
            Sozlesmeler = new HashSet<Sozlesmeler>();
        }

        [Key]
        public int Sozlesmetur_ID { get; set; }

        [StringLength(50)]
        public string Sozlesmetur_AD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sozlesmeler> Sozlesmeler { get; set; }
    }
}
