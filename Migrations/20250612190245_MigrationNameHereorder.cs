using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzaliaJwellery.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNameHereorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Engraving",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GemStone",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductDiamondId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "OrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Engraving",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "GemStone",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductDiamondId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "OrderDetail");
        }
    }
}
