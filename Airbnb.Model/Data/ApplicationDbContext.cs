using Airbnb.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Model.Data;

public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<Models.Airbnb> Airbnbs { get; set; }

    public virtual DbSet<AirbnbAmenity> AirbnbAmenities { get; set; }

    public virtual DbSet<AirbnbCategory> AirbnbCategories { get; set; }

    public virtual DbSet<AirbnbMedium> AirbnbMedia { get; set; }

    public virtual DbSet<AirbnbType> AirbnbTypes { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<AmenityType> AmenityTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Models.Airbnb>(entity =>
        {
            entity.HasKey(e => e.AirbnbId);

            entity.Property(e => e.AirbnbId).ValueGeneratedNever();
            entity.Property(e => e.Bathrooms).HasColumnType("decimal(3,1)");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

            entity.HasOne(d => d.AirbnbType).WithMany(p => p.Airbnbs)
                .HasForeignKey(d => d.AirbnbTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Category).WithMany(p => p.Airbnbs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Host).WithMany(p => p.Airbnbs)
                .HasForeignKey(d => d.HostId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AirbnbAmenity>(entity =>
        {
            entity.HasKey(e => e.AirbnbAmenityId);

            entity.Property(e => e.AirbnbAmenityId).ValueGeneratedNever();

            entity.HasOne(d => d.Airbnb).WithMany(p => p.AirbnbAmenities)
                .HasForeignKey(d => d.AirbnbId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Amenity).WithMany(p => p.AirbnbAmenities)
                .HasForeignKey(d => d.AmenityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AirbnbCategory>(entity =>
        {
            entity.HasKey(e => e.AirbnbCategoryId);

            entity.Property(e => e.AirbnbCategoryId).ValueGeneratedNever();
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AirbnbMedium>(entity =>
        {
            entity.HasKey(e => e.AirbnbMediaId);

            entity.Property(e => e.AirbnbMediaId).ValueGeneratedNever();
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Airbnb).WithMany(p => p.AirbnbMedia)
                .HasForeignKey(d => d.AirbnbId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AirbnbType>(entity =>
        {
            entity.HasKey(e => e.AirbnbTypeId);

            entity.Property(e => e.AirbnbTypeId).ValueGeneratedNever();
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId);

            entity.Property(e => e.AmenityId).ValueGeneratedNever();
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AmenityType).WithMany(p => p.Amenities)
                .HasForeignKey(d => d.AmenityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AmenityType>(entity =>
        {
            entity.HasKey(e => e.AmenityTypeId);

            entity.Property(e => e.AmenityTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
