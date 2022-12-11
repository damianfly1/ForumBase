using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class trim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c9dd30-d572-4be8-88df-037926db54ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af41d9b-6c0e-4ce8-87e4-dfee4924f625");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97bd620c-8ff4-4b6a-9ab4-e396775ac009");

            migrationBuilder.DropColumn(
                name: "ResponseCount",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Footer",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64293d2a-710d-42ef-b143-3e853a625f89", "f214a0fd-df65-4ae2-8b72-160043b4c118", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be42e99f-b0f1-458e-a4ce-fd11fd1df54a", "8e612b87-0a89-4281-ab1c-da033c0b7e9a", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc6a24fb-6667-48b7-b357-2a6f1219ebee", "02f36689-5a7c-45b8-ba15-9ffd614ae944", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64293d2a-710d-42ef-b143-3e853a625f89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be42e99f-b0f1-458e-a4ce-fd11fd1df54a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc6a24fb-6667-48b7-b357-2a6f1219ebee");

            migrationBuilder.AddColumn<int>(
                name: "ResponseCount",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Footer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70c9dd30-d572-4be8-88df-037926db54ad", "6042fa9c-d51f-4f69-a23b-f1f4c242f18d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8af41d9b-6c0e-4ce8-87e4-dfee4924f625", "132c6ae9-1c02-4062-9149-3322427e6a2c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97bd620c-8ff4-4b6a-9ab4-e396775ac009", "c0084b5b-144b-4f34-bc84-75d9e191cc8b", "Moderator", "MODERATOR" });
        }
    }
}
