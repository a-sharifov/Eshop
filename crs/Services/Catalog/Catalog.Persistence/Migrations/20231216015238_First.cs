using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistence.Migrations;

/// <inheritdoc />
public partial class First : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Brands",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Brands", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "outboxMessageConsumers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_outboxMessageConsumers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "outboxMessages",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_outboxMessages", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Sellers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SellerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Sellers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Price_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    name: "FK_Products_Brands_BrandId",
                    column: x => x.BrandId,
                    principalTable: "Brands",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Products_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Products_Sellers_SellerId",
                    column: x => x.SellerId,
                    principalTable: "Sellers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Products_BrandId",
            table: "Products",
            column: "BrandId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_CategoryId",
            table: "Products",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_SellerId",
            table: "Products",
            column: "SellerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "outboxMessageConsumers");

        migrationBuilder.DropTable(
            name: "outboxMessages");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Brands");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Sellers");
    }
}
