using Microsoft.EntityFrameworkCore.Migrations;

namespace KeepHome.Data.Migrations
{
    public partial class InitialImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ParentCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ChildCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ChildCategories");
        }
    }
}
