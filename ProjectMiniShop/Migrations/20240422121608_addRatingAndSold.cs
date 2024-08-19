using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMiniShop.Migrations
{
    /// <inheritdoc />
    public partial class addRatingAndSold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sold",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "sold",
                table: "Products");
        }
    }
}
