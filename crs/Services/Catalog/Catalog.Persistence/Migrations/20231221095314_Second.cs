using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistence.Migrations;

/// <inheritdoc />
public partial class Second : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Products_Brands_BrandId",
            table: "Products");

        migrationBuilder.DropForeignKey(
            name: "FK_Products_Categories_CategoryId",
            table: "Products");

        migrationBuilder.DropForeignKey(
            name: "FK_Products_Sellers_SellerId",
            table: "Products");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Sellers",
            table: "Sellers");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Products",
            table: "Products");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Categories",
            table: "Categories");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Brands",
            table: "Brands");

        migrationBuilder.RenameTable(
            name: "Sellers",
            newName: "Seller");

        migrationBuilder.RenameTable(
            name: "Products",
            newName: "Product");

        migrationBuilder.RenameTable(
            name: "Categories",
            newName: "Category");

        migrationBuilder.RenameTable(
            name: "Brands",
            newName: "Brand");

        migrationBuilder.RenameIndex(
            name: "IX_Products_SellerId",
            table: "Product",
            newName: "IX_Product_SellerId");

        migrationBuilder.RenameIndex(
            name: "IX_Products_CategoryId",
            table: "Product",
            newName: "IX_Product_CategoryId");

        migrationBuilder.RenameIndex(
            name: "IX_Products_BrandId",
            table: "Product",
            newName: "IX_Product_BrandId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Seller",
            table: "Seller",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Product",
            table: "Product",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Category",
            table: "Category",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Brand",
            table: "Brand",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Product_Brand_BrandId",
            table: "Product",
            column: "BrandId",
            principalTable: "Brand",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Product_Category_CategoryId",
            table: "Product",
            column: "CategoryId",
            principalTable: "Category",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Product_Seller_SellerId",
            table: "Product",
            column: "SellerId",
            principalTable: "Seller",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Product_Brand_BrandId",
            table: "Product");

        migrationBuilder.DropForeignKey(
            name: "FK_Product_Category_CategoryId",
            table: "Product");

        migrationBuilder.DropForeignKey(
            name: "FK_Product_Seller_SellerId",
            table: "Product");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Seller",
            table: "Seller");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Product",
            table: "Product");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Category",
            table: "Category");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Brand",
            table: "Brand");

        migrationBuilder.RenameTable(
            name: "Seller",
            newName: "Sellers");

        migrationBuilder.RenameTable(
            name: "Product",
            newName: "Products");

        migrationBuilder.RenameTable(
            name: "Category",
            newName: "Categories");

        migrationBuilder.RenameTable(
            name: "Brand",
            newName: "Brands");

        migrationBuilder.RenameIndex(
            name: "IX_Product_SellerId",
            table: "Products",
            newName: "IX_Products_SellerId");

        migrationBuilder.RenameIndex(
            name: "IX_Product_CategoryId",
            table: "Products",
            newName: "IX_Products_CategoryId");

        migrationBuilder.RenameIndex(
            name: "IX_Product_BrandId",
            table: "Products",
            newName: "IX_Products_BrandId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Sellers",
            table: "Sellers",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Products",
            table: "Products",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Categories",
            table: "Categories",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Brands",
            table: "Brands",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Products_Brands_BrandId",
            table: "Products",
            column: "BrandId",
            principalTable: "Brands",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Products_Categories_CategoryId",
            table: "Products",
            column: "CategoryId",
            principalTable: "Categories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Products_Sellers_SellerId",
            table: "Products",
            column: "SellerId",
            principalTable: "Sellers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
