using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzaliaJwellery.Migrations
{
    /// <inheritdoc />
    public partial class AddJewelleryTypeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_JewelleryType_JewelleryTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_JewelleryTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "JewelleryTypeId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JewelleryTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_JewelleryTypeId",
                table: "Products",
                column: "JewelleryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_JewelleryType_JewelleryTypeId",
                table: "Products",
                column: "JewelleryTypeId",
                principalTable: "JewelleryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
