using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_AuthorId",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "CategoryModerator");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2992333e-6a26-4be8-aede-87919555cb7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e55dc26-4347-4a0b-a166-b87ffbf4feb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8226ee8d-d0ed-402d-84e5-659e71199c4f");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId1",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId1",
                table: "Posts",
                column: "TopicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId1",
                table: "Posts",
                column: "TopicId1",
                principalTable: "Topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_AuthorId",
                table: "Topics",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId1",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_AuthorId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TopicId1",
                table: "Posts");

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

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryModerator",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModerator", x => new { x.UserId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryModerator_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryModerator_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2992333e-6a26-4be8-aede-87919555cb7f", "b7e87243-b847-4c0c-909d-5a66358a8b68", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e55dc26-4347-4a0b-a166-b87ffbf4feb2", "5beb3eaa-643f-41bb-b0d5-545f01dc181d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8226ee8d-d0ed-402d-84e5-659e71199c4f", "68c5ef99-ebde-47b9-a69c-fbe7dd6b8dc9", "Moderator", "MODERATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModerator_CategoryId",
                table: "CategoryModerator",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_AuthorId",
                table: "Topics",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
