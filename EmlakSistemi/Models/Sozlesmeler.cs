namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sozlesmeler")]
    public partial class Sozlesmeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sozlesmeler()
        {
            Satislar = new HashSet<Satislar>();
        }

        [Key]
        public int Sozlesme_ID { get; set; }

        [StringLength(50)]
        public string Sozlesme_BASLIK { get; set; }

        [StringLength(50)]
        public string Sozlesme_ACIKLAMA { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Sozlesme_BASTARIH { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Sozlesme_BITTARIH { get; set; }

        [StringLength(50)]
        public string Sozlesme_KISIAD { get; set; }

        [StringLength(50)]
        public string Sozlesme_KISISOYAD { get; set; }

        public int? Mahalle_ID { get; set; }

        public int? Sozlesme_KAPINO { get; set; }

        public int? Sozlesme_PAFTANO { get; set; }

        public int? Sozlesme_ADANO { get; set; }

        public int? Sozlesme_PARSELNO { get; set; }

        public int? Sozlemetur_ID { get; set; }

        public Guid? UserId { get; set; }

        public int? Sozlesme_NO { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }

        public virtual SozlesmeTuru SozlesmeTuru { get; set; }
    }
}
