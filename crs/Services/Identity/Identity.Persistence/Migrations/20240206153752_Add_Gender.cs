using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations;

/// <inheritdoc />
public partial class Add_Gender : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_outboxMessageConsumers",
            table: "outboxMessageConsumers");

        migrationBuilder.RenameTable(
            name: "outboxMessageConsumers",
            newName: "OutboxMessageConsumers");

        migrationBuilder.AlterColumn<string>(
            name: "Role",
            table: "User",
            type: "text",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer");

        migrationBuilder.AddColumn<string>(
            name: "Gender",
            table: "User",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddPrimaryKey(
            name: "PK_OutboxMessageConsumers",
            table: "OutboxMessageConsumers",
            column: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_OutboxMessageConsumers",
            table: "OutboxMessageConsumers");

        migrationBuilder.DropColumn(
            name: "Gender",
            table: "User");

        migrationBuilder.RenameTable(
            name: "OutboxMessageConsumers",
            newName: "outboxMessageConsumers");

        migrationBuilder.AlterColumn<int>(
            name: "Role",
            table: "User",
            type: "integer",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AddPrimaryKey(
            name: "PK_outboxMessageConsumers",
            table: "outboxMessageConsumers",
            column: "Id");
    }
}
