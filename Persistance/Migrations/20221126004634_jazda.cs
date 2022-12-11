using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class jazda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af98c35-4c41-4e48-b660-eee9ef148855");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e59de7-16b5-4de4-88b7-758abb309431");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86e49a67-90ce-48d1-89a8-44acbb6212cb");

            migrationBuilder.RenameColumn(
                name: "ViewsCount",
                table: "Topics",
                newName: "ViewCount");

            migrationBuilder.AddColumn<int>(
                name: "ResponseCount",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ViewCount",
                table: "Topics",
                newName: "ViewsCount");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2af98c35-4c41-4e48-b660-eee9ef148855", "6fff8b82-edb5-4a3c-b8c7-6c3454133236", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80e59de7-16b5-4de4-88b7-758abb309431", "b3ef76ef-a88b-41b7-aa57-c65bb9a13a1e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86e49a67-90ce-48d1-89a8-44acbb6212cb", "e282205b-d780-4b9a-970b-7814e6f86124", "Moderator", "MODERATOR" });
        }
    }
}
