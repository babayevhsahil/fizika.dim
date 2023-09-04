using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizika.Data.Migrations
{
    public partial class VideoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Exams");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(2749), new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(1489), new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(4696), new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(4694), new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(4697) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(4704), new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(4702), new DateTime(2021, 11, 28, 16, 4, 0, 848, DateTimeKind.Local).AddTicks(4705) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 885, DateTimeKind.Local).AddTicks(188), new DateTime(2021, 11, 28, 16, 4, 0, 885, DateTimeKind.Local).AddTicks(204) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 885, DateTimeKind.Local).AddTicks(214), new DateTime(2021, 11, 28, 16, 4, 0, 885, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 885, DateTimeKind.Local).AddTicks(220), new DateTime(2021, 11, 28, 16, 4, 0, 885, DateTimeKind.Local).AddTicks(222) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 851, DateTimeKind.Local).AddTicks(8947), new DateTime(2021, 11, 28, 16, 4, 0, 851, DateTimeKind.Local).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 851, DateTimeKind.Local).AddTicks(8969), new DateTime(2021, 11, 28, 16, 4, 0, 851, DateTimeKind.Local).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 4, 0, 883, DateTimeKind.Local).AddTicks(1281), new DateTime(2021, 11, 28, 16, 4, 0, 883, DateTimeKind.Local).AddTicks(1298) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "747fd45a-d07b-4cb8-8dd8-a061bcb6bd83");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3a236008-a649-4975-a0c8-8e313ee27bca");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "58a1cca6-a3b6-47cc-af85-4149f863cda5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "089dd818-4596-4705-a5d7-2022074bfe20");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "c1a5b99c-4ca4-477e-899d-f3811966289d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "c60c981f-39ce-4f2b-9622-5e577785c813");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "733df86d-15ef-4a9e-a8e1-018656e4cfe8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "f1c20355-174d-48c8-bbff-1f6a24372e97");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "9b7ce691-b270-420d-9e56-e7f5d8add8bd");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "655c57a0-753e-40d0-ae7b-7a4a566f4532");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "b5081de5-f2e5-472f-bc81-08667162103f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "42d614ba-ccd8-4756-ba1b-c7efbc906cb2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "1b63becc-e607-4b7a-98ce-1405e9c796b6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "c11eced5-4017-4068-a2bb-2edb3c7f0bb5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "99d88508-dda0-47c2-af2b-8d19a7a11516");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "186fa6a8-a005-43f7-a212-a38b6c27e2b1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "3284a5ba-e960-45b0-a390-b63c3876e393");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "81128b82-37ea-45c8-a7be-b1fbfff542d5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "740b79df-3e44-491b-9530-ee08c3e97180");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "a42fa1f0-31da-4353-a44c-da75bc96f808");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "05252a93-6fef-400b-8de9-eec8937065ea");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "58ded085-44e1-490c-895b-7217ef6511b0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55dcf8a5-0073-4232-9f9a-814250a28bcb", "AQAAAAEAACcQAAAAEA2ar9qGnK/o9dX3d5B3TXA6AU8OF/RbyahNgMgbPvxg7ovrMd/t9ufKvAMGtlolHA==", "8dc33d9d-410c-4d8a-80c5-618e0477f82f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22eebecf-db32-4984-a5fe-bb8a084eec45", "AQAAAAEAACcQAAAAENrDrjQd3Xidn1EynZxGSbOpL5SmETXCw6WvLxME3bu02mVcw8tYUwwTfGEoT5WyyA==", "80ba7277-6b1a-4dd6-997f-cbe636d87797" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "Link", "ModifiedByName", "ModifiedDate", "Thumbnail", "Title" },
                values: new object[] { 1, "InitialCreate", new DateTime(2021, 11, 28, 16, 4, 0, 907, DateTimeKind.Local).AddTicks(5742), true, false, "C# Programlama Dili ile İlgili En Güncel Bilgiler", "InitialCreate", new DateTime(2021, 11, 28, 16, 4, 0, 907, DateTimeKind.Local).AddTicks(5758), "C# Programlama Dili ile İlgili En Güncel Bilgiler", "C#" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Exams",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(4991), new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(3258), new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(7371), new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(7368), new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(7373) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(7381), new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(7379), new DateTime(2021, 11, 20, 14, 1, 26, 88, DateTimeKind.Local).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 138, DateTimeKind.Local).AddTicks(9631), new DateTime(2021, 11, 20, 14, 1, 26, 138, DateTimeKind.Local).AddTicks(9656) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 138, DateTimeKind.Local).AddTicks(9698), new DateTime(2021, 11, 20, 14, 1, 26, 138, DateTimeKind.Local).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 138, DateTimeKind.Local).AddTicks(9706), new DateTime(2021, 11, 20, 14, 1, 26, 138, DateTimeKind.Local).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 93, DateTimeKind.Local).AddTicks(7773), new DateTime(2021, 11, 20, 14, 1, 26, 93, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 93, DateTimeKind.Local).AddTicks(7807), new DateTime(2021, 11, 20, 14, 1, 26, 93, DateTimeKind.Local).AddTicks(7809) });

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 11, 20, 14, 1, 26, 136, DateTimeKind.Local).AddTicks(5461), new DateTime(2021, 11, 20, 14, 1, 26, 136, DateTimeKind.Local).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fca87047-e7d6-4cc8-9d25-db080a6c39ef");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f321e8c7-10c8-4344-b8ea-09eafb8ea6c8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "ed7f774d-9ed9-4b35-a868-36d2d737216f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "47164a9d-a0e7-4c23-9f4c-020de9abb05e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "15bb8266-0894-47ee-982a-28576ba21c61");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "2a2a7fd6-b35c-41c0-9415-8ef77daa8f04");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "7f6b55ff-0331-4284-b2ce-cea90a547184");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "c6cea27e-530e-47b9-92ef-316e7bc8796f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "7d968510-76bf-4131-8bcd-da78178c3125");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "f4d394a7-bbfc-4b69-8c44-8711182be184");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "a98927d1-b26d-41cd-ae1f-7cd10c839ea3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "e220b8a3-5ca5-44eb-a394-6ed8aec5caca");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "7792c775-1425-4ae3-b191-1b82a00b4fc5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "a7dc8920-dbea-4ed9-a58c-e336fb5d19d5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "747284b8-1b0b-4cde-b394-36042f9ed396");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "fcb398d2-272e-40df-a629-78c03359c129");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "9e273e79-4441-4e8f-b522-5ec04b4abca0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "e35c10ba-011e-4e83-a772-ff75f742a217");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "d229f247-9687-45f0-b02e-5014645c60df");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "bbe44e95-2087-4f7a-ac53-28b60b866066");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "39c1cb75-4291-4f96-88f8-4f803a2c9063");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "b1d4ea2a-9945-4ccd-8645-19c9b03b59b1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a83ee98d-9d9b-47f2-82c7-33887a0396a8", "AQAAAAEAACcQAAAAECbaLCAaL8UvgpIJ7VAm2C5fqUEjZQzxUSMnAx1/c//gKPhD4TRMCyyBOaDrkeSorA==", "7a9e3544-6556-46ee-9f78-6b3bcf68ce09" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77a56940-3374-44f4-ba47-33fd95acc695", "AQAAAAEAACcQAAAAEEJ0BabjdD7SRNnG9H31XJB7VD22nyGPaS5iGeVCOzAyUWaHp97yYWh1pUtDCUxmAw==", "c32e13cb-41a0-4edd-881a-785d0124aebd" });
        }
    }
}
