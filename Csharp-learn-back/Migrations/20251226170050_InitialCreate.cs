using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharplearn.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CurrentExperiencePoints = table.Column<int>(type: "integer", nullable: false),
                    Stats_Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Stats_Spirit = table.Column<int>(type: "integer", nullable: false),
                    Stats_Force = table.Column<int>(type: "integer", nullable: false),
                    Stats_Constitution = table.Column<int>(type: "integer", nullable: false),
                    Stats_Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Stats_Agility = table.Column<int>(type: "integer", nullable: false),
                    Stats_Speed = table.Column<int>(type: "integer", nullable: false),
                    Stats_Luck = table.Column<int>(type: "integer", nullable: false),
                    Stats_Health = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
