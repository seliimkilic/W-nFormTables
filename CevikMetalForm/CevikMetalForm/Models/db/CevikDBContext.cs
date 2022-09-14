using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CevikMetalForm.Models.db
{
    public partial class CevikDBContext : DbContext
    {
        public CevikDBContext()
        {
        }

        public CevikDBContext(DbContextOptions<CevikDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FirmaTablo> FirmaTablos { get; set; }
        public virtual DbSet<PersonelTablo> PersonelTablos { get; set; }
        public virtual DbSet<SistemTablo> SistemTablos { get; set; }
        public virtual DbSet<StokTablo> StokTablos { get; set; }
        public virtual DbSet<UrunTablo> UrunTablos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JT2ALK4\\SQLEXPRESS;Database=CevikDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FirmaTablo>(entity =>
            {
                entity.ToTable("FirmaTablo");

                entity.Property(e => e.Musteri).HasMaxLength(50);
            });

            modelBuilder.Entity<PersonelTablo>(entity =>
            {
                entity.ToTable("PersonelTablo");

                entity.Property(e => e.Departman).HasMaxLength(50);

                entity.Property(e => e.PersonelAdSoyad).HasMaxLength(50);
            });

            modelBuilder.Entity<SistemTablo>(entity =>
            {
                entity.ToTable("SistemTablo");

                entity.Property(e => e.OdenenMiktar).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Firma)
                    .WithMany(p => p.SistemTablos)
                    .HasForeignKey(d => d.FirmaId)
                    .HasConstraintName("FK_SistemTablo_FirmaTablo");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.SistemTablos)
                    .HasForeignKey(d => d.PersonelId)
                    .HasConstraintName("FK_SistemTablo_PersonelTablo");

                entity.HasOne(d => d.Stok)
                    .WithMany(p => p.SistemTablos)
                    .HasForeignKey(d => d.StokId)
                    .HasConstraintName("FK_SistemTablo_StokTablo");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SistemTablos)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SistemTablo_UrunTablo");
            });

            modelBuilder.Entity<StokTablo>(entity =>
            {
                entity.ToTable("StokTablo");

                entity.Property(e => e.StokMaliyeti).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StokTutarı).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.StokTablos)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_StokTablo_UrunTablo");
            });

            modelBuilder.Entity<UrunTablo>(entity =>
            {
                entity.ToTable("UrunTablo");

                entity.Property(e => e.UrunAdı).HasMaxLength(50);

                entity.Property(e => e.UrunFiyatı).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UrunMarka).HasMaxLength(50);

                entity.Property(e => e.UrunTıpı).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
