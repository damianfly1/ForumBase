using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class remove_subsubforum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subforums_Subforums_ParentId",
                table: "Subforums");

            migrationBuilder.DropIndex(
                name: "IX_Subforums_ParentId",
                table: "Subforums");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Subforums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Subforums",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subforums_ParentId",
                table: "Subforums",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subforums_Subforums_ParentId",
                table: "Subforums",
                column: "ParentId",
                principalTable: "Subforums",
                principalColumn: "Id");
        }
    }
}
