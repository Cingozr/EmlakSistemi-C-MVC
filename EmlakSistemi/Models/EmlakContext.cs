namespace EmlakSistemi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmlakContext : DbContext
    {
        public EmlakContext()
            : base("name=EmlakContext")
        {
        }

        public virtual DbSet<AltKategori> AltKategori { get; set; }
        public virtual DbSet<AnaKategori> AnaKategori { get; set; }
        public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual DbSet<aspnet_Paths> aspnet_Paths { get; set; }
        public virtual DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
        public virtual DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public virtual DbSet<aspnet_Profile> aspnet_Profile { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
        public virtual DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
        public virtual DbSet<BinaYasBilgisi> BinaYasBilgisi { get; set; }
        public virtual DbSet<Bulten> Bulten { get; set; }
        public virtual DbSet<Cephe> Cephe { get; set; }
        public virtual DbSet<DisOzellik> DisOzellik { get; set; }
        public virtual DbSet<DurumBilgisi> DurumBilgisi { get; set; }
        public virtual DbSet<EngelliUygunluk> EngelliUygunluk { get; set; }
        public virtual DbSet<Firmalar> Firmalar { get; set; }
        public virtual DbSet<FirmaTur> FirmaTur { get; set; }
        public virtual DbSet<Hatirlatma> Hatirlatma { get; set; }
        public virtual DbSet<IcOzellik> IcOzellik { get; set; }
        public virtual DbSet<IlanKonutTip> IlanKonutTip { get; set; }
        public virtual DbSet<Ilanlar> Ilanlar { get; set; }
        public virtual DbSet<IsıtmaBilgisi> IsıtmaBilgisi { get; set; }
        public virtual DbSet<ilceler> ilceler { get; set; }
        public virtual DbSet<iller> iller { get; set; }
        public virtual DbSet<KatBilgisi> KatBilgisi { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<KonutTipi> KonutTipi { get; set; }
        public virtual DbSet<Lokasyon> Lokasyon { get; set; }
        public virtual DbSet<Mahalle> Mahalle { get; set; }
        public virtual DbSet<Manzara> Manzara { get; set; }
        public virtual DbSet<Medya> Medya { get; set; }
        public virtual DbSet<Mesaj> Mesaj { get; set; }
        public virtual DbSet<Muhit> Muhit { get; set; }
        public virtual DbSet<OdaBilgisi> OdaBilgisi { get; set; }
        public virtual DbSet<Randevu> Randevu { get; set; }
        public virtual DbSet<SatisDetay> SatisDetay { get; set; }
        public virtual DbSet<Satislar> Satislar { get; set; }
        public virtual DbSet<Sozlesmeler> Sozlesmeler { get; set; }
        public virtual DbSet<SozlesmeTuru> SozlesmeTuru { get; set; }
        public virtual DbSet<Ulasim> Ulasim { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Paths)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Roles)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Users)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Paths>()
                .HasOptional(e => e.aspnet_PersonalizationAllUsers)
                .WithRequired(e => e.aspnet_Paths);

            modelBuilder.Entity<aspnet_Roles>()
                .HasMany(e => e.aspnet_Users)
                .WithMany(e => e.aspnet_Roles)
                .Map(m => m.ToTable("aspnet_UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Profile)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_Users>()
                .HasMany(e => e.Ilanlar)
                .WithOptional(e => e.aspnet_Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<aspnet_Users>()
                .HasMany(e => e.Ilanlar1)
                .WithMany(e => e.aspnet_Users1)
                .Map(m => m.ToTable("Favoriler").MapLeftKey("UserId").MapRightKey("Ilan_ID"));

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventSequence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventOccurrence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<Cephe>()
                .HasMany(e => e.Ilanlar)
                .WithMany(e => e.Cephe)
                .Map(m => m.ToTable("IlanCephe").MapLeftKey("Cephe_ID").MapRightKey("Ilan_ID"));

            modelBuilder.Entity<DisOzellik>()
                .HasMany(e => e.Ilanlar)
                .WithMany(e => e.DisOzellik)
                .Map(m => m.ToTable("IlanDisOzellik").MapLeftKey("DisOzellik_ID").MapRightKey("Ilan_ID"));

            modelBuilder.Entity<EngelliUygunluk>()
                .HasMany(e => e.Ilanlar)
                .WithMany(e => e.EngelliUygunluk)
                .Map(m => m.ToTable("IlanEngelliUygunluk").MapLeftKey("EngelliUygunluk_ID").MapRightKey("Ilan_ID"));

            modelBuilder.Entity<IcOzellik>()
                .HasMany(e => e.Ilanlar)
                .WithMany(e => e.IcOzellik)
                .Map(m => m.ToTable("IlanIcOzellik").MapLeftKey("IcOzellik_ID").MapRightKey("Ilan_ID"));

            modelBuilder.Entity<Ilanlar>()
                .Property(e => e.Ilan_FIYAT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ilanlar>()
                .HasMany(e => e.IlanKonutTip)
                .WithRequired(e => e.Ilanlar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ilanlar>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.Ilanlar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ilanlar>()
                .HasMany(e => e.Manzara)
                .WithMany(e => e.Ilanlar)
                .Map(m => m.ToTable("IlanManzara").MapLeftKey("Ilan_ID").MapRightKey("Manzara_ID"));

            modelBuilder.Entity<Ilanlar>()
                .HasMany(e => e.Medya)
                .WithMany(e => e.Ilanlar)
                .Map(m => m.ToTable("IlanMedya").MapLeftKey("Ilan_ID").MapRightKey("Medya_ID"));

            modelBuilder.Entity<Ilanlar>()
                .HasMany(e => e.Muhit)
                .WithMany(e => e.Ilanlar)
                .Map(m => m.ToTable("IlanMuhit").MapLeftKey("Ilan_ID").MapRightKey("Muhit_ID"));

            modelBuilder.Entity<Ilanlar>()
                .HasMany(e => e.Ulasim)
                .WithMany(e => e.Ilanlar)
                .Map(m => m.ToTable("IlanUlasim").MapLeftKey("Ilan_ID").MapRightKey("Ulasim_ID"));

            modelBuilder.Entity<iller>()
                .HasMany(e => e.ilceler)
                .WithRequired(e => e.iller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KonutTipi>()
                .HasMany(e => e.IlanKonutTip)
                .WithRequired(e => e.KonutTipi)
                .HasForeignKey(e => e.Ilan_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Satislar>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.Satislar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SozlesmeTuru>()
                .HasMany(e => e.Sozlesmeler)
                .WithOptional(e => e.SozlesmeTuru)
                .HasForeignKey(e => e.Sozlemetur_ID);
        }
    }
}
