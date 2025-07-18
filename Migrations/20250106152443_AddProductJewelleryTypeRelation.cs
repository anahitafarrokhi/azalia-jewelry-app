﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzaliaJwellery.Migrations
{
    /// <inheritdoc />
    public partial class AddProductJewelleryTypeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductJewelleryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    JewelleryTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductJewelleryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductJewelleryType_JewelleryType_JewelleryTypeId",
                        column: x => x.JewelleryTypeId,
                        principalTable: "JewelleryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
            table.ForeignKey(
                        name: "FK_ProductJewelleryType_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductJewelleryType_JewelleryTypeId",
                table: "ProductJewelleryType",
                column: "JewelleryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductJewelleryType_ProductId",
                table: "ProductJewelleryType",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductJewelleryType");
        }
    }
}
