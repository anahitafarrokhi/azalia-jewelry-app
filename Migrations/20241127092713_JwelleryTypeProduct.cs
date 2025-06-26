using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzaliaJwellery.Migrations
{
    /// <inheritdoc />
    public partial class JwelleryTypeProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_JewelleryType_JewelleryTypeId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategory_JewelleryTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_JewelleryTypeId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "JewelleryTypeId1",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_JewelleryType_JewelleryTypeId",
                table: "Products",
                column: "JewelleryTypeId",
                principalTable: "JewelleryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_JewelleryType_JewelleryTypeId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "JewelleryTypeId1",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_JewelleryTypeId1",
                table: "Products",
                column: "JewelleryTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_JewelleryType_JewelleryTypeId1",
                table: "Products",
                column: "JewelleryTypeId1",
                principalTable: "JewelleryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategory_JewelleryTypeId",
                table: "Products",
                column: "JewelleryTypeId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
