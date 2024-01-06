using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations;

/// <inheritdoc />
public partial class AddEmailToken : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "EmailConfirmationToken",
            table: "User",
            type: "text",
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "EmailConfirmationToken",
            table: "User");
    }
}
