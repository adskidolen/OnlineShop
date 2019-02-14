using Microsoft.EntityFrameworkCore.Migrations;

namespace KeepHome.Data.Migrations
{
    public partial class BlogPost_IsEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEdited",
                table: "BlogPosts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEdited",
                table: "BlogPosts");
        }
    }
}
