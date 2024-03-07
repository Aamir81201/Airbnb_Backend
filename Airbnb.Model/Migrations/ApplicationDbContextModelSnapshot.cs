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

                    b.Property<long?>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<long?>("Longitude")
                        .HasColumnType("bigint");

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

                    b.HasData(
                        new
                        {
                            AirbnbCategoryId = new Guid("54845521-e8d1-4140-9a01-23e8b9980501"),
                            Icon = "5cdb8451-8f75-4c5f-a17d-33ee228e3db8",
                            Name = "Windmill"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("293ad374-e3bf-42d9-82db-fc63e4ffe25b"),
                            Icon = "e22b0816-f0f3-42a0-a5db-e0f1fa93292b",
                            Name = "Guest house"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("1dbf5bdc-bd9f-4e3e-8502-096779602b26"),
                            Icon = "0ff9740e-52a2-4cd5-ae5a-94e1bfb560d6",
                            Name = "Container"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("ab5ad5c8-c19c-4136-acf5-887539ca42f8"),
                            Icon = "251c0635-cc91-4ef7-bb13-1084d5229446",
                            Name = "Casa particular"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("d84b1742-244b-4fd8-9abd-94d7f9660725"),
                            Icon = "33848f9e-8dd6-4777-b905-ed38342bacb9",
                            Name = "Trullo"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("c847b717-e88c-4fab-a69b-dff0d89d5d78"),
                            Icon = "732edad8-3ae0-49a8-a451-29a8010dcc0c",
                            Name = "Cabin"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("933856e6-df79-4ce0-af3f-788d0a150ebf"),
                            Icon = "827c5623-d182-474a-823c-db3894490896",
                            Name = "Ryokan"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("39c2e870-b2f1-4395-b4fe-8a20be859b62"),
                            Icon = "f60700bc-8ab5-424c-912b-6ef17abc479a",
                            Name = "Barn"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("9aa297e1-a531-44f6-9ae2-3660d16381ba"),
                            Icon = "4221e293-4770-4ea8-a4fa-9972158d4004",
                            Name = "Cave"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("ffd62c34-ac66-4c54-b069-467c13e4e954"),
                            Icon = "c027ff1a-b89c-4331-ae04-f8dee1cdc287",
                            Name = "Houseboat"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("b1ab1034-94c8-4d36-a707-243c0273beb0"),
                            Icon = "d7445031-62c4-46d0-91c3-4f29f9790f7a",
                            Name = "Earth home"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("1151d5fb-eb93-4197-965c-8253bb47a21b"),
                            Icon = "48b55f09-f51c-4ff5-b2c6-7f6bd4d1e049",
                            Name = "Minsu"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("7f9310ac-d1e2-4542-9819-e6262cc3598b"),
                            Icon = "4759a0a7-96a8-4dcd-9490-ed785af6df14",
                            Name = "Yurt"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("4df61c6e-90cd-46a0-96ce-7bd13effdf8d"),
                            Icon = "aaa02c2d-9f0d-4c41-878a-68c12ec6c6bd",
                            Name = "Farm"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("a52ddd7b-6640-4b93-9aa1-055b1e085027"),
                            Icon = "50861fca-582c-4bcc-89d3-857fb7ca6528",
                            Name = "House"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("756a6949-d1fc-4bef-a378-206d732bae51"),
                            Icon = "51f5cf64-5821-400c-8033-8a10c7787d69",
                            Name = "Kezhan"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("e624cdd9-b335-40ab-bb03-d508b5dd8123"),
                            Icon = "ca25c7f3-0d1f-432b-9efa-b9f5dc6d8770",
                            Name = "Tent"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("2b3ae884-33e6-492d-b1ab-69a51a735777"),
                            Icon = "4d4a4eba-c7e4-43eb-9ce2-95e1d200d10e",
                            Name = "Tree house"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("cdbb85c1-88fb-4e46-a16b-c5f87dc4bdc3"),
                            Icon = "89faf9ae-bbbc-4bc4-aecd-cc15bf36cbca",
                            Name = "Dome"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("cd79dc54-aff6-49bf-8f60-5b1183dad059"),
                            Icon = "31c1d523-cc46-45b3-957a-da76c30c85f9",
                            Name = "Campervan"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("50f5103e-2526-42e3-a23e-bda2102110bc"),
                            Icon = "3271df99-f071-4ecf-9128-eb2d2b1f50f0",
                            Name = "Tiny home"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("4f15dc43-7a2b-4e71-808c-09970ef78662"),
                            Icon = "e4b12c1b-409b-4cb6-a674-7c1284449f6e",
                            Name = "Cycladic home"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("719da685-9a94-4472-bcd7-5d0f92588422"),
                            Icon = "747b326c-cb8f-41cf-a7f9-809ab646e10c",
                            Name = "Shepherd's hut"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("7ac1dc88-df78-4aad-902b-c61ef65a9fe4"),
                            Icon = "d721318f-4752-417d-b4fa-77da3cbc3269",
                            Name = "Tower"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("920ca6ba-ab9e-45a7-a6fb-52d71281b0ed"),
                            Icon = "c9157d0a-98fe-4516-af81-44022118fbc7",
                            Name = "Dammuso"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("520d7b41-c485-4432-9341-ffa52812a057"),
                            Icon = "5ed8f7c7-2e1f-43a8-9a39-4edfc81a3325",
                            Name = "Bed & breakfast"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("fe6e4675-159e-412b-ae13-8459de849487"),
                            Icon = "1b6a8b70-a3b6-48b5-88e1-2243d9172c06",
                            Name = "Castle"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("cba4b1c3-81c4-4dd9-beda-96b4be34d2de"),
                            Icon = "7ff6e4a1-51b4-4671-bc9a-6f523f196c61",
                            Name = "Raid"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("9e26e9dc-78e0-41a9-9a30-7b796024cbf9"),
                            Icon = "687a8682-68b3-4f21-8d71-3c3aef6c1110",
                            Name = "Boat"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("45cbb49e-67b7-45a1-b2fd-e7ddfd4c47f2"),
                            Icon = "78ba8486-6ba6-4a43-a56d-f556189193da",
                            Name = "Hotel"
                        },
                        new
                        {
                            AirbnbCategoryId = new Guid("a73e34a5-f8cd-4caf-b1a6-dda415e60977"),
                            Icon = "c28365a2-404a-4d43-a3f9-fb4b6ab2b7bb",
                            Name = "Flat"
                        });
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

                    b.HasData(
                        new
                        {
                            AirbnbTypeId = new Guid("679d253f-a9a5-419c-a30b-e6cc7e375aac"),
                            Icon = "house",
                            Name = "An entire place"
                        },
                        new
                        {
                            AirbnbTypeId = new Guid("30409539-81f2-40f2-b35d-d5af8bc58da9"),
                            Icon = "house",
                            Name = "A room"
                        },
                        new
                        {
                            AirbnbTypeId = new Guid("4a584c7f-3685-4478-9f1a-2c2e53ea89e0"),
                            Icon = "house",
                            Name = "A shared room"
                        });
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

                    b.HasData(
                        new
                        {
                            AmenityTypeId = new Guid("e3fb2d47-6dd5-4f70-8235-875282624aaf"),
                            Name = "Scenic Views"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("68d54e25-21f2-4380-a60d-758d73b87c17"),
                            Name = "Bathroom"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("2919d20b-4994-4a47-94e6-11a77f6d84cf"),
                            Name = "Bedroom and Laundry"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("1bfa7d59-cd9f-48d5-9ba9-842f6f4f98ee"),
                            Name = "Entertainment"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("169fcff8-c72f-4dab-b676-e997dee643bb"),
                            Name = "Heating and Cooling"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("a2d4a71a-cecf-422a-98b2-ef17714776f6"),
                            Name = "Home Safety"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("f76c26d5-c159-4c6d-9527-f6e1882e729f"),
                            Name = "Internet and Office"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("585fc3fe-34aa-408c-9eb5-89251fe0ad0d"),
                            Name = "Kitchen and Dining"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("bb8a8154-8266-47f2-af61-6fd88aaf4eb9"),
                            Name = "Location Features"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("f58c80da-6223-4940-91aa-78884aad1a98"),
                            Name = "Outdoor"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("9c1801a7-eda3-4492-84b6-6fe19d014a91"),
                            Name = "Parking and Facilities"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("3e927b4d-9350-4f99-985a-b4bf28157d2b"),
                            Name = "Services"
                        },
                        new
                        {
                            AmenityTypeId = new Guid("a3eeb96d-101d-4476-b4c5-3569091f0b6a"),
                            Name = "Family"
                        });
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
