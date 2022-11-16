using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class addedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "479a0465-ab43-4d4d-ad46-b35a845ed9d6", "2d897076-6c6b-4be9-b5d9-d5ae7096566c", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c308e12-55b2-4d1f-8679-5da48366d5dc", "937d32cd-4402-4af6-9fdc-9d2210c5aff9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "787f3a6c-e29a-47ca-8378-ead4592c3ed9", "7a5aa4b1-33df-4a33-bf02-ffd655a02224", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "479a0465-ab43-4d4d-ad46-b35a845ed9d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c308e12-55b2-4d1f-8679-5da48366d5dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "787f3a6c-e29a-47ca-8378-ead4592c3ed9");
        }
    }
}
