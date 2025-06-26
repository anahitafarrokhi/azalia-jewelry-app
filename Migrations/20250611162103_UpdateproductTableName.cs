using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzaliaJwellery.Migrations
{
    /// <inheritdoc />
    public partial class UpdateproductTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clarity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiamondColor",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clarity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiamondColor",
                table: "Products");
        }
    }
}
