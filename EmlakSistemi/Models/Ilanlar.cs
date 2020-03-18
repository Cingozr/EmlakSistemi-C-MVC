namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ilanlar")]
    public partial class Ilanlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilanlar()
        {
            IlanKonutTip = new HashSet<IlanKonutTip>();
            SatisDetay = new HashSet<SatisDetay>();
            aspnet_Users1 = new HashSet<aspnet_Users>();
            Cephe = new HashSet<Cephe>();
            DisOzellik = new HashSet<DisOzellik>();
            EngelliUygunluk = new HashSet<EngelliUygunluk>();
            IcOzellik = new HashSet<IcOzellik>();
            Manzara = new HashSet<Manzara>();
            Medya = new HashSet<Medya>();
            Muhit = new HashSet<Muhit>();
            Ulasim = new HashSet<Ulasim>();
        }

        [Key]
        public int Ilan_ID { get; set; }

        public int? Ilan_NO { get; set; }

        [StringLength(300)]
        public string Ilan_AD { get; set; }

        public string Ilan_ACIKLAMA { get; set; }

        [Column(TypeName = "money")]
        public decimal? Ilan_FIYAT { get; set; }

        [StringLength(50)]
        public string Ilan_AIDAT { get; set; }

        public int? Lokasyon_ID { get; set; }

        public int? Ilan_METREKARE { get; set; }

        public int? Mahalle_ID { get; set; }

        public int? Kat_ID { get; set; }

        public int? BinaYas_ID { get; set; }

        public int? KullanimDurum_ID { get; set; }

        public int? Oda_ID { get; set; }

        public int? Isıtma_ID { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Ilan_TARIHI { get; set; }

        public bool? Ilan_AKTIF { get; set; }

        public bool? Ilan_ESYADURUM { get; set; }

        public bool? Ilan_KRKEDIDURUM { get; set; }

        public bool? Vitrin { get; set; }

        public int? Ilan_GORUNTULENME { get; set; }

        public int? AnaKategori_ID { get; set; }

        public Guid? UserId { get; set; }

        public virtual AnaKategori AnaKategori { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual BinaYasBilgisi BinaYasBilgisi { get; set; }

        public virtual DurumBilgisi DurumBilgisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IlanKonutTip> IlanKonutTip { get; set; }

        public virtual IsıtmaBilgisi IsıtmaBilgisi { get; set; }

        public virtual KatBilgisi KatBilgisi { get; set; }

        public virtual Lokasyon Lokasyon { get; set; }

        public virtual Mahalle Mahalle { get; set; }

        public virtual OdaBilgisi OdaBilgisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_Users> aspnet_Users1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cephe> Cephe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisOzellik> DisOzellik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EngelliUygunluk> EngelliUygunluk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IcOzellik> IcOzellik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manzara> Manzara { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medya> Medya { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Muhit> Muhit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ulasim> Ulasim { get; set; }
    }
}
