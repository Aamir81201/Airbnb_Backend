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

            entity.HasData(
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Windmill",
                    Icon = "5cdb8451-8f75-4c5f-a17d-33ee228e3db8",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Guest house",
                    Icon = "e22b0816-f0f3-42a0-a5db-e0f1fa93292b",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Container",
                    Icon = "0ff9740e-52a2-4cd5-ae5a-94e1bfb560d6",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Casa particular",
                    Icon = "251c0635-cc91-4ef7-bb13-1084d5229446",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Trullo",
                    Icon = "33848f9e-8dd6-4777-b905-ed38342bacb9",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Cabin",
                    Icon = "732edad8-3ae0-49a8-a451-29a8010dcc0c",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Ryokan",
                    Icon = "827c5623-d182-474a-823c-db3894490896",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Barn",
                    Icon = "f60700bc-8ab5-424c-912b-6ef17abc479a",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Cave",
                    Icon = "4221e293-4770-4ea8-a4fa-9972158d4004",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Houseboat",
                    Icon = "c027ff1a-b89c-4331-ae04-f8dee1cdc287",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Earth home",
                    Icon = "d7445031-62c4-46d0-91c3-4f29f9790f7a",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Minsu",
                    Icon = "48b55f09-f51c-4ff5-b2c6-7f6bd4d1e049",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Yurt",
                    Icon = "4759a0a7-96a8-4dcd-9490-ed785af6df14",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Farm",
                    Icon = "aaa02c2d-9f0d-4c41-878a-68c12ec6c6bd",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "House",
                    Icon = "50861fca-582c-4bcc-89d3-857fb7ca6528",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Kezhan",
                    Icon = "51f5cf64-5821-400c-8033-8a10c7787d69",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Tent",
                    Icon = "ca25c7f3-0d1f-432b-9efa-b9f5dc6d8770",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Tree house",
                    Icon = "4d4a4eba-c7e4-43eb-9ce2-95e1d200d10e",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Dome",
                    Icon = "89faf9ae-bbbc-4bc4-aecd-cc15bf36cbca",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Campervan",
                    Icon = "31c1d523-cc46-45b3-957a-da76c30c85f9",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Tiny home",
                    Icon = "3271df99-f071-4ecf-9128-eb2d2b1f50f0",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Cycladic home",
                    Icon = "e4b12c1b-409b-4cb6-a674-7c1284449f6e",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Shepherd's hut",
                    Icon = "747b326c-cb8f-41cf-a7f9-809ab646e10c",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Tower",
                    Icon = "d721318f-4752-417d-b4fa-77da3cbc3269",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Dammuso",
                    Icon = "c9157d0a-98fe-4516-af81-44022118fbc7",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Bed & breakfast",
                    Icon = "5ed8f7c7-2e1f-43a8-9a39-4edfc81a3325",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Castle",
                    Icon = "1b6a8b70-a3b6-48b5-88e1-2243d9172c06",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Raid",
                    Icon = "7ff6e4a1-51b4-4671-bc9a-6f523f196c61",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Boat",
                    Icon = "687a8682-68b3-4f21-8d71-3c3aef6c1110",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Hotel",
                    Icon = "78ba8486-6ba6-4a43-a56d-f556189193da",
                },
                new AirbnbCategory
                {
                    AirbnbCategoryId = Guid.NewGuid(),
                    Name = "Flat",
                    Icon = "c28365a2-404a-4d43-a3f9-fb4b6ab2b7bb",
                }
            );
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

            entity.HasData(
                new AirbnbType
                {
                    AirbnbTypeId = Guid.NewGuid(),
                    Name = "An entire place",
                    Icon = "house"
                },
                new AirbnbType
                {
                    AirbnbTypeId = Guid.NewGuid(),
                    Name = "A room",
                    Icon = "house"
                },
                new AirbnbType
                {
                    AirbnbTypeId = Guid.NewGuid(),
                    Name = "A shared room",
                    Icon = "house"
                }
            );
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

            entity.HasData(
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Scenic Views"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Bathroom"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Bedroom and Laundry"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Entertainment"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Heating and Cooling"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Home Safety"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Internet and Office"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Kitchen and Dining"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Location Features"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Outdoor"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Parking and Facilities"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Services"
                },
                new AmenityType
                {
                    AmenityTypeId = Guid.NewGuid(),
                    Name = "Family"
                }
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
