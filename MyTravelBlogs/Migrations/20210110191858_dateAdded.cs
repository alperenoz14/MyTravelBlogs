using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTravelBlogs.Migrations
{
    public partial class dateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_blogs_blogId",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "blogId",
                table: "comments",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_blogId",
                table: "comments",
                newName: "IX_comments_BlogId");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_comments_blogs_BlogId",
                table: "comments",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "blogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_blogs_BlogId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "date",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "comments",
                newName: "blogId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_BlogId",
                table: "comments",
                newName: "IX_comments_blogId");

            migrationBuilder.AlterColumn<int>(
                name: "userName",
                table: "comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "blogId",
                table: "comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_comments_blogs_blogId",
                table: "comments",
                column: "blogId",
                principalTable: "blogs",
                principalColumn: "blogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
