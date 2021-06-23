using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_ZiekenhuisOpnames.Migrations
{
    public partial class AddPatientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Leeftijd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Straat = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    HuisNr = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Bus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Geslacht = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    pathImgIdCardVoorkant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pathImgIdCardAchterkant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
