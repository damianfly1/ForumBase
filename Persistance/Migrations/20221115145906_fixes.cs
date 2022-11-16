using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65ea1592-c291-4b6f-80a6-3e40a3b152a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e037168-515f-442d-abf3-a641a44d7371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8818f54-a670-4c3f-b41a-65b4b40095c1");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedById",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84541247-3038-4c88-b605-0e03ce84725f", "8ff8eb8c-6812-4b49-8fcf-6242f40929f6", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90c12837-fa2b-4057-b9e6-9ab39c4b3bea", "fb3b4e9b-c3b8-4dca-8a29-8dfe51916912", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e23d7d14-4ded-4327-8062-484e9fb04097", "81b79333-9078-40bd-be6e-e8979af6757f", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84541247-3038-4c88-b605-0e03ce84725f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90c12837-fa2b-4057-b9e6-9ab39c4b3bea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23d7d14-4ded-4327-8062-484e9fb04097");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedById",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65ea1592-c291-4b6f-80a6-3e40a3b152a7", "d993fdff-21c8-4d64-b270-0ef43d9b7206", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e037168-515f-442d-abf3-a641a44d7371", "6be6b6e7-091e-4acf-8722-9810422b44e2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8818f54-a670-4c3f-b41a-65b4b40095c1", "d0846435-2572-4f46-8991-3c92e20bf83b", "User", "USER" });
        }
    }
}
