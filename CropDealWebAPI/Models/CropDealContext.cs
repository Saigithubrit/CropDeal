using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CropDealWebAPI.Models
{
    public partial class CropDealContext : DbContext
    {
        public CropDealContext()
        {
        }

        public CropDealContext(DbContextOptions<CropDealContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Crop> Crops { get; set; } = null!;
        public virtual DbSet<CropOnSale> CropOnSales { get; set; } = null!;
        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-NKUJCDUA\\SQLEXPRESS; Database=CropDeal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AdminEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Crop>(entity =>
            {
                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.CropImage).IsUnicode(false);

                entity.Property(e => e.CropName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CropOnSale>(entity =>
            {
                entity.HasKey(e => e.CropAdId);

                entity.ToTable("CropOnSale");

                entity.Property(e => e.CropAdId).HasColumnName("CropAdID");

                entity.Property(e => e.CropName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CropPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CropType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.CropOnSales)
                    .HasForeignKey(d => d.CropId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CropOnSale_CropId");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.CropOnSales)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CropOnSale_CropOnSale");
            });

            modelBuilder.Entity<ExceptionLog>(entity =>
            {
                entity.ToTable("ExceptionLog");

                entity.Property(e => e.ErrorCausedAt).IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.CropName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.DealerAccNumberNavigation)
                    .WithMany(p => p.InvoiceDealerAccNumberNavigations)
                    .HasPrincipalKey(p => p.UserAccnumber)
                    .HasForeignKey(d => d.DealerAccNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_UserProfile");

                entity.HasOne(d => d.FarmerAccNumberNavigation)
                    .WithMany(p => p.InvoiceFarmerAccNumberNavigations)
                    .HasPrincipalKey(p => p.UserAccnumber)
                    .HasForeignKey(d => d.FarmerAccNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_Farmer");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserProfile_1");

                entity.ToTable("UserProfile");

                entity.HasIndex(e => e.UserAccnumber, "IX_UserProfile")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserBankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserIfsc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UserIFSC");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ACTIVE')");

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
