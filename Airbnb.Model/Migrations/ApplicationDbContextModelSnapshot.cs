﻿// <auto-generated />
using System;
using Airbnb.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Airbnb.Model.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Airbnb.Model.Models.Airbnb", b =>
                {
                    b.Property<Guid>("AirbnbId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirbnbTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Bathrooms")
                        .HasColumnType("decimal(3,1)");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("Guests")
                        .HasColumnType("int");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AirbnbId");

                    b.HasIndex("AirbnbTypeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("HostId");

                    b.ToTable("Airbnbs");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbAmenity", b =>
                {
                    b.Property<Guid>("AirbnbAmenityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirbnbId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AmenityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AirbnbAmenityId");

                    b.HasIndex("AirbnbId");

                    b.HasIndex("AmenityId");

                    b.ToTable("AirbnbAmenities");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbCategory", b =>
                {
                    b.Property<Guid>("AirbnbCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AirbnbCategoryId");

                    b.ToTable("AirbnbCategories");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbMedium", b =>
                {
                    b.Property<Guid>("AirbnbMediaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirbnbId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HeroImage")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AirbnbMediaId");

                    b.HasIndex("AirbnbId");

                    b.ToTable("AirbnbMedia");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbType", b =>
                {
                    b.Property<Guid>("AirbnbTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AirbnbTypeId");

                    b.ToTable("AirbnbTypes");
                });

            modelBuilder.Entity("Airbnb.Model.Models.Amenity", b =>
                {
                    b.Property<Guid>("AmenityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AmenityTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("AmenityId");

                    b.HasIndex("AmenityTypeId");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AmenityType", b =>
                {
                    b.Property<Guid>("AmenityTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AmenityTypeId");

                    b.ToTable("AmenityTypes");
                });

            modelBuilder.Entity("Airbnb.Model.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("RecieveMarketingMessages")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Airbnb.Model.Models.Airbnb", b =>
                {
                    b.HasOne("Airbnb.Model.Models.AirbnbType", "AirbnbType")
                        .WithMany("Airbnbs")
                        .HasForeignKey("AirbnbTypeId")
                        .IsRequired();

                    b.HasOne("Airbnb.Model.Models.AirbnbCategory", "Category")
                        .WithMany("Airbnbs")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.HasOne("Airbnb.Model.Models.ApplicationUser", "Host")
                        .WithMany("Airbnbs")
                        .HasForeignKey("HostId")
                        .IsRequired();

                    b.Navigation("AirbnbType");

                    b.Navigation("Category");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbAmenity", b =>
                {
                    b.HasOne("Airbnb.Model.Models.Airbnb", "Airbnb")
                        .WithMany("AirbnbAmenities")
                        .HasForeignKey("AirbnbId")
                        .IsRequired();

                    b.HasOne("Airbnb.Model.Models.Amenity", "Amenity")
                        .WithMany("AirbnbAmenities")
                        .HasForeignKey("AmenityId")
                        .IsRequired();

                    b.Navigation("Airbnb");

                    b.Navigation("Amenity");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbMedium", b =>
                {
                    b.HasOne("Airbnb.Model.Models.Airbnb", "Airbnb")
                        .WithMany("AirbnbMedia")
                        .HasForeignKey("AirbnbId")
                        .IsRequired();

                    b.Navigation("Airbnb");
                });

            modelBuilder.Entity("Airbnb.Model.Models.Amenity", b =>
                {
                    b.HasOne("Airbnb.Model.Models.AmenityType", "AmenityType")
                        .WithMany("Amenities")
                        .HasForeignKey("AmenityTypeId")
                        .IsRequired();

                    b.Navigation("AmenityType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Airbnb.Model.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Airbnb.Model.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Airbnb.Model.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Airbnb.Model.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airbnb.Model.Models.Airbnb", b =>
                {
                    b.Navigation("AirbnbAmenities");

                    b.Navigation("AirbnbMedia");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbCategory", b =>
                {
                    b.Navigation("Airbnbs");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AirbnbType", b =>
                {
                    b.Navigation("Airbnbs");
                });

            modelBuilder.Entity("Airbnb.Model.Models.Amenity", b =>
                {
                    b.Navigation("AirbnbAmenities");
                });

            modelBuilder.Entity("Airbnb.Model.Models.AmenityType", b =>
                {
                    b.Navigation("Amenities");
                });

            modelBuilder.Entity("Airbnb.Model.Models.ApplicationUser", b =>
                {
                    b.Navigation("Airbnbs");
                });
#pragma warning restore 612, 618
        }
    }
}
