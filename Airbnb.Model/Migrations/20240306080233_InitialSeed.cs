using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Airbnb.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AirbnbCategories",
                columns: new[] { "AirbnbCategoryId", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("1151d5fb-eb93-4197-965c-8253bb47a21b"), "48b55f09-f51c-4ff5-b2c6-7f6bd4d1e049", "Minsu" },
                    { new Guid("1dbf5bdc-bd9f-4e3e-8502-096779602b26"), "0ff9740e-52a2-4cd5-ae5a-94e1bfb560d6", "Container" },
                    { new Guid("293ad374-e3bf-42d9-82db-fc63e4ffe25b"), "e22b0816-f0f3-42a0-a5db-e0f1fa93292b", "Guest house" },
                    { new Guid("2b3ae884-33e6-492d-b1ab-69a51a735777"), "4d4a4eba-c7e4-43eb-9ce2-95e1d200d10e", "Tree house" },
                    { new Guid("39c2e870-b2f1-4395-b4fe-8a20be859b62"), "f60700bc-8ab5-424c-912b-6ef17abc479a", "Barn" },
                    { new Guid("45cbb49e-67b7-45a1-b2fd-e7ddfd4c47f2"), "78ba8486-6ba6-4a43-a56d-f556189193da", "Hotel" },
                    { new Guid("4df61c6e-90cd-46a0-96ce-7bd13effdf8d"), "aaa02c2d-9f0d-4c41-878a-68c12ec6c6bd", "Farm" },
                    { new Guid("4f15dc43-7a2b-4e71-808c-09970ef78662"), "e4b12c1b-409b-4cb6-a674-7c1284449f6e", "Cycladic home" },
                    { new Guid("50f5103e-2526-42e3-a23e-bda2102110bc"), "3271df99-f071-4ecf-9128-eb2d2b1f50f0", "Tiny home" },
                    { new Guid("520d7b41-c485-4432-9341-ffa52812a057"), "5ed8f7c7-2e1f-43a8-9a39-4edfc81a3325", "Bed & breakfast" },
                    { new Guid("54845521-e8d1-4140-9a01-23e8b9980501"), "5cdb8451-8f75-4c5f-a17d-33ee228e3db8", "Windmill" },
                    { new Guid("719da685-9a94-4472-bcd7-5d0f92588422"), "747b326c-cb8f-41cf-a7f9-809ab646e10c", "Shepherd's hut" },
                    { new Guid("756a6949-d1fc-4bef-a378-206d732bae51"), "51f5cf64-5821-400c-8033-8a10c7787d69", "Kezhan" },
                    { new Guid("7ac1dc88-df78-4aad-902b-c61ef65a9fe4"), "d721318f-4752-417d-b4fa-77da3cbc3269", "Tower" },
                    { new Guid("7f9310ac-d1e2-4542-9819-e6262cc3598b"), "4759a0a7-96a8-4dcd-9490-ed785af6df14", "Yurt" },
                    { new Guid("920ca6ba-ab9e-45a7-a6fb-52d71281b0ed"), "c9157d0a-98fe-4516-af81-44022118fbc7", "Dammuso" },
                    { new Guid("933856e6-df79-4ce0-af3f-788d0a150ebf"), "827c5623-d182-474a-823c-db3894490896", "Ryokan" },
                    { new Guid("9aa297e1-a531-44f6-9ae2-3660d16381ba"), "4221e293-4770-4ea8-a4fa-9972158d4004", "Cave" },
                    { new Guid("9e26e9dc-78e0-41a9-9a30-7b796024cbf9"), "687a8682-68b3-4f21-8d71-3c3aef6c1110", "Boat" },
                    { new Guid("a52ddd7b-6640-4b93-9aa1-055b1e085027"), "50861fca-582c-4bcc-89d3-857fb7ca6528", "House" },
                    { new Guid("a73e34a5-f8cd-4caf-b1a6-dda415e60977"), "c28365a2-404a-4d43-a3f9-fb4b6ab2b7bb", "Flat" },
                    { new Guid("ab5ad5c8-c19c-4136-acf5-887539ca42f8"), "251c0635-cc91-4ef7-bb13-1084d5229446", "Casa particular" },
                    { new Guid("b1ab1034-94c8-4d36-a707-243c0273beb0"), "d7445031-62c4-46d0-91c3-4f29f9790f7a", "Earth home" },
                    { new Guid("c847b717-e88c-4fab-a69b-dff0d89d5d78"), "732edad8-3ae0-49a8-a451-29a8010dcc0c", "Cabin" },
                    { new Guid("cba4b1c3-81c4-4dd9-beda-96b4be34d2de"), "7ff6e4a1-51b4-4671-bc9a-6f523f196c61", "Raid" },
                    { new Guid("cd79dc54-aff6-49bf-8f60-5b1183dad059"), "31c1d523-cc46-45b3-957a-da76c30c85f9", "Campervan" },
                    { new Guid("cdbb85c1-88fb-4e46-a16b-c5f87dc4bdc3"), "89faf9ae-bbbc-4bc4-aecd-cc15bf36cbca", "Dome" },
                    { new Guid("d84b1742-244b-4fd8-9abd-94d7f9660725"), "33848f9e-8dd6-4777-b905-ed38342bacb9", "Trullo" },
                    { new Guid("e624cdd9-b335-40ab-bb03-d508b5dd8123"), "ca25c7f3-0d1f-432b-9efa-b9f5dc6d8770", "Tent" },
                    { new Guid("fe6e4675-159e-412b-ae13-8459de849487"), "1b6a8b70-a3b6-48b5-88e1-2243d9172c06", "Castle" },
                    { new Guid("ffd62c34-ac66-4c54-b069-467c13e4e954"), "c027ff1a-b89c-4331-ae04-f8dee1cdc287", "Houseboat" }
                });

            migrationBuilder.InsertData(
                table: "AirbnbTypes",
                columns: new[] { "AirbnbTypeId", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("30409539-81f2-40f2-b35d-d5af8bc58da9"), "house", "A room" },
                    { new Guid("4a584c7f-3685-4478-9f1a-2c2e53ea89e0"), "house", "A shared room" },
                    { new Guid("679d253f-a9a5-419c-a30b-e6cc7e375aac"), "house", "An entire place" }
                });

            migrationBuilder.InsertData(
                table: "AmenityTypes",
                columns: new[] { "AmenityTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("169fcff8-c72f-4dab-b676-e997dee643bb"), "Heating and Cooling" },
                    { new Guid("1bfa7d59-cd9f-48d5-9ba9-842f6f4f98ee"), "Entertainment" },
                    { new Guid("2919d20b-4994-4a47-94e6-11a77f6d84cf"), "Bedroom and Laundry" },
                    { new Guid("3e927b4d-9350-4f99-985a-b4bf28157d2b"), "Services" },
                    { new Guid("585fc3fe-34aa-408c-9eb5-89251fe0ad0d"), "Kitchen and Dining" },
                    { new Guid("68d54e25-21f2-4380-a60d-758d73b87c17"), "Bathroom" },
                    { new Guid("9c1801a7-eda3-4492-84b6-6fe19d014a91"), "Parking and Facilities" },
                    { new Guid("a2d4a71a-cecf-422a-98b2-ef17714776f6"), "Home Safety" },
                    { new Guid("a3eeb96d-101d-4476-b4c5-3569091f0b6a"), "Family" },
                    { new Guid("bb8a8154-8266-47f2-af61-6fd88aaf4eb9"), "Location Features" },
                    { new Guid("e3fb2d47-6dd5-4f70-8235-875282624aaf"), "Scenic Views" },
                    { new Guid("f58c80da-6223-4940-91aa-78884aad1a98"), "Outdoor" },
                    { new Guid("f76c26d5-c159-4c6d-9527-f6e1882e729f"), "Internet and Office" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("1151d5fb-eb93-4197-965c-8253bb47a21b"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("1dbf5bdc-bd9f-4e3e-8502-096779602b26"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("293ad374-e3bf-42d9-82db-fc63e4ffe25b"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("2b3ae884-33e6-492d-b1ab-69a51a735777"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("39c2e870-b2f1-4395-b4fe-8a20be859b62"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("45cbb49e-67b7-45a1-b2fd-e7ddfd4c47f2"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("4df61c6e-90cd-46a0-96ce-7bd13effdf8d"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("4f15dc43-7a2b-4e71-808c-09970ef78662"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("50f5103e-2526-42e3-a23e-bda2102110bc"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("520d7b41-c485-4432-9341-ffa52812a057"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("54845521-e8d1-4140-9a01-23e8b9980501"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("719da685-9a94-4472-bcd7-5d0f92588422"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("756a6949-d1fc-4bef-a378-206d732bae51"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("7ac1dc88-df78-4aad-902b-c61ef65a9fe4"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("7f9310ac-d1e2-4542-9819-e6262cc3598b"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("920ca6ba-ab9e-45a7-a6fb-52d71281b0ed"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("933856e6-df79-4ce0-af3f-788d0a150ebf"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("9aa297e1-a531-44f6-9ae2-3660d16381ba"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("9e26e9dc-78e0-41a9-9a30-7b796024cbf9"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("a52ddd7b-6640-4b93-9aa1-055b1e085027"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("a73e34a5-f8cd-4caf-b1a6-dda415e60977"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("ab5ad5c8-c19c-4136-acf5-887539ca42f8"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("b1ab1034-94c8-4d36-a707-243c0273beb0"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("c847b717-e88c-4fab-a69b-dff0d89d5d78"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("cba4b1c3-81c4-4dd9-beda-96b4be34d2de"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("cd79dc54-aff6-49bf-8f60-5b1183dad059"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("cdbb85c1-88fb-4e46-a16b-c5f87dc4bdc3"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("d84b1742-244b-4fd8-9abd-94d7f9660725"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("e624cdd9-b335-40ab-bb03-d508b5dd8123"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("fe6e4675-159e-412b-ae13-8459de849487"));

            migrationBuilder.DeleteData(
                table: "AirbnbCategories",
                keyColumn: "AirbnbCategoryId",
                keyValue: new Guid("ffd62c34-ac66-4c54-b069-467c13e4e954"));

            migrationBuilder.DeleteData(
                table: "AirbnbTypes",
                keyColumn: "AirbnbTypeId",
                keyValue: new Guid("30409539-81f2-40f2-b35d-d5af8bc58da9"));

            migrationBuilder.DeleteData(
                table: "AirbnbTypes",
                keyColumn: "AirbnbTypeId",
                keyValue: new Guid("4a584c7f-3685-4478-9f1a-2c2e53ea89e0"));

            migrationBuilder.DeleteData(
                table: "AirbnbTypes",
                keyColumn: "AirbnbTypeId",
                keyValue: new Guid("679d253f-a9a5-419c-a30b-e6cc7e375aac"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("169fcff8-c72f-4dab-b676-e997dee643bb"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("1bfa7d59-cd9f-48d5-9ba9-842f6f4f98ee"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("2919d20b-4994-4a47-94e6-11a77f6d84cf"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("3e927b4d-9350-4f99-985a-b4bf28157d2b"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("585fc3fe-34aa-408c-9eb5-89251fe0ad0d"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("68d54e25-21f2-4380-a60d-758d73b87c17"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("9c1801a7-eda3-4492-84b6-6fe19d014a91"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("a2d4a71a-cecf-422a-98b2-ef17714776f6"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("a3eeb96d-101d-4476-b4c5-3569091f0b6a"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("bb8a8154-8266-47f2-af61-6fd88aaf4eb9"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("e3fb2d47-6dd5-4f70-8235-875282624aaf"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("f58c80da-6223-4940-91aa-78884aad1a98"));

            migrationBuilder.DeleteData(
                table: "AmenityTypes",
                keyColumn: "AmenityTypeId",
                keyValue: new Guid("f76c26d5-c159-4c6d-9527-f6e1882e729f"));
        }
    }
}
