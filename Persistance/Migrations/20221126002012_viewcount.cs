using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class viewcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79387aea-e74b-45c7-ab74-5bc3f1c3d0d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87cc854a-859f-444d-848e-81ba6b010aa6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c295859f-5464-4c75-87d9-595c18b1255c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a4ecefd-abc6-4678-988f-f00187bfd62f", "7bbec67a-88b6-4bd3-b678-10e51af57f6f", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55133184-1149-4fbe-a951-38f14291cf13", "1fd42c63-6af8-49ba-b5c4-a4fc8195de5d", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6dda0eb5-3901-4e1f-a1af-ada8ad6894e6", "39e73323-65f5-4a7f-bfb8-460ea4747918", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a4ecefd-abc6-4678-988f-f00187bfd62f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55133184-1149-4fbe-a951-38f14291cf13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dda0eb5-3901-4e1f-a1af-ada8ad6894e6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79387aea-e74b-45c7-ab74-5bc3f1c3d0d4", "0b026c44-f7a8-4229-a880-80952cc159cd", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87cc854a-859f-444d-848e-81ba6b010aa6", "e56b0973-4c0c-42ac-9fad-a1f6906b1d8b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c295859f-5464-4c75-87d9-595c18b1255c", "6cd5bccb-dee9-4404-860e-b28c24b25f94", "User", "USER" });
        }
    }
}
