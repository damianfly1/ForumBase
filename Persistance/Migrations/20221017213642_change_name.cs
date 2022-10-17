using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class change_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Subforums_SubforumId",
                table: "Topics");

            migrationBuilder.RenameColumn(
                name: "SubforumId",
                table: "Topics",
                newName: "SubForumId");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_SubforumId",
                table: "Topics",
                newName: "IX_Topics_SubForumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Subforums_SubForumId",
                table: "Topics",
                column: "SubForumId",
                principalTable: "Subforums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Subforums_SubForumId",
                table: "Topics");

            migrationBuilder.RenameColumn(
                name: "SubForumId",
                table: "Topics",
                newName: "SubforumId");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_SubForumId",
                table: "Topics",
                newName: "IX_Topics_SubforumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Subforums_SubforumId",
                table: "Topics",
                column: "SubforumId",
                principalTable: "Subforums",
                principalColumn: "Id");
        }
    }
}
