using System;
using System.Collections.Generic;
using Airbnb.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.DataModels.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Airbnb> Airbnbs { get; set; }

    public virtual DbSet<AirbnbAmenity> AirbnbAmenities { get; set; }

    public virtual DbSet<AirbnbCategory> AirbnbCategories { get; set; }

    public virtual DbSet<AirbnbMedium> AirbnbMedia { get; set; }

    public virtual DbSet<AirbnbType> AirbnbTypes { get; set; }

    public virtual DbSet<Airbnbtemp> Airbnbtemps { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<AmenityType> AmenityTypes { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Airbnb>(entity =>
        {
            entity.HasKey(e => e.AirbnbId).HasName("PK__Airbnb__7FCD3C0DEA8F3363");

            entity.ToTable("Airbnb");

            entity.Property(e => e.AirbnbId).ValueGeneratedNever();
            entity.Property(e => e.Bathrooms).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.AirbnbType).WithMany(p => p.Airbnbs)
                .HasForeignKey(d => d.AirbnbTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Airbnb__AirbnbTy__5D95E53A");

            entity.HasOne(d => d.Category).WithMany(p => p.Airbnbs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Airbnb__Category__5E8A0973");

            entity.HasOne(d => d.Host).WithMany(p => p.Airbnbs)
                .HasForeignKey(d => d.HostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Airbnb__HostId__5F7E2DAC");
        });

        modelBuilder.Entity<AirbnbAmenity>(entity =>
        {
            entity.HasKey(e => e.AirbnbAmenityId).HasName("PK__AirbnbAm__9B7A403D0E0F9254");

            entity.ToTable("AirbnbAmenity");

            entity.Property(e => e.AirbnbAmenityId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Airbnb).WithMany(p => p.AirbnbAmenities)
                .HasForeignKey(d => d.AirbnbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AirbnbAme__Airbn__634EBE90");

            entity.HasOne(d => d.Amenity).WithMany(p => p.AirbnbAmenities)
                .HasForeignKey(d => d.AmenityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AirbnbAme__Ameni__625A9A57");
        });

        modelBuilder.Entity<AirbnbCategory>(entity =>
        {
            entity.HasKey(e => e.AirbnbCategoryId).HasName("PK__AirbnbCa__A4F4820A8ACDA0B4");

            entity.ToTable("AirbnbCategory");

            entity.Property(e => e.AirbnbCategoryId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AirbnbMedium>(entity =>
        {
            entity.HasKey(e => e.AirbnbMediaId).HasName("PK__AirbnbMe__6A77B735DB775010");

            entity.Property(e => e.AirbnbMediaId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Airbnb).WithMany(p => p.AirbnbMedia)
                .HasForeignKey(d => d.AirbnbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AirbnbMed__Airbn__662B2B3B");
        });

        modelBuilder.Entity<AirbnbType>(entity =>
        {
            entity.HasKey(e => e.AirbnbTypeId).HasName("PK__AirbnbTy__DACAD02439647B21");

            entity.ToTable("AirbnbType");

            entity.Property(e => e.AirbnbTypeId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Airbnbtemp>(entity =>
        {
            entity.HasKey(e => e.AirbnbId).HasName("PK__Airbnbte__7FCD3C0D6E69575C");

            entity.ToTable("Airbnbtemp");

            entity.Property(e => e.AirbnbId).ValueGeneratedNever();
            entity.Property(e => e.Bathrooms).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.AirbnbType).WithMany(p => p.Airbnbtemps)
                .HasForeignKey(d => d.AirbnbTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Airbnbtem__Airbn__56E8E7AB");

            entity.HasOne(d => d.Category).WithMany(p => p.Airbnbtemps)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Airbnbtem__Categ__57DD0BE4");

            entity.HasOne(d => d.Host).WithMany(p => p.Airbnbtemps)
                .HasForeignKey(d => d.HostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Airbnbtem__HostI__58D1301D");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("PK__Amenity__842AF50B62426533");

            entity.ToTable("Amenity");

            entity.Property(e => e.AmenityId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AmenityType).WithMany(p => p.Amenities)
                .HasForeignKey(d => d.AmenityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Amenity__Amenity__3D2915A8");
        });

        modelBuilder.Entity<AmenityType>(entity =>
        {
            entity.HasKey(e => e.AmenityTypeId).HasName("PK__AmenityT__6C1E9D2CFEDC2BD3");

            entity.ToTable("AmenityType");

            entity.Property(e => e.AmenityTypeId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
