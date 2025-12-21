using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharplearn.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PlayerStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stats_Agility",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Constitution",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Dexterity",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Force",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Intelligence",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Luck",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Speed",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Spirit",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stats_Agility",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stats_Constitution",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stats_Dexterity",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stats_Force",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stats_Intelligence",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stats_Luck",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stats_Speed",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stats_Spirit",
                table: "Players");
        }
    }
}
