using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TopicId1",
                table: "Posts");

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

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c21d796-fff0-489c-b79c-fd2890c76cf0", "4aa0146f-aff0-45f0-a5ed-2efcb7284fac", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9151cdf1-81db-4b08-b8df-9a7043d17462", "1a62e484-a3c9-47ea-a5aa-69c4704be79c", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5b28cb7-d52f-4bc3-a4a4-1957285ab6d6", "40a91087-1cae-4358-b868-78b69e6d50ed", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c21d796-fff0-489c-b79c-fd2890c76cf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9151cdf1-81db-4b08-b8df-9a7043d17462");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5b28cb7-d52f-4bc3-a4a4-1957285ab6d6");

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId1",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId1",
                table: "Posts",
                column: "TopicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId1",
                table: "Posts",
                column: "TopicId1",
                principalTable: "Topics",
                principalColumn: "Id");
        }
    }
}
