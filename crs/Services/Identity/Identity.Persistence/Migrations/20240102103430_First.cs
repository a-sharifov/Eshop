using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations;

/// <inheritdoc />
public partial class First : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "OutboxMessages",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Type = table.Column<string>(type: "text", nullable: false),
                Message = table.Column<string>(type: "text", nullable: false),
                ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Error = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OutboxMessages", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "User",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                PasswordHash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                PasswordSalt = table.Column<string>(type: "text", nullable: false),
                RefreshToken_Token = table.Column<string>(type: "text", nullable: true),
                RefreshToken_Expired = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Role = table.Column<int>(type: "integer", nullable: false),
                IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "outboxMessageConsumers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_outboxMessageConsumers", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OutboxMessages");

        migrationBuilder.DropTable(
            name: "User");

        migrationBuilder.DropTable(
            name: "outboxMessageConsumers");
    }
}
