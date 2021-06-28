using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_ZiekenhuisOpnames.Migrations
{
    public partial class AddIDImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "ImgAchterkantId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImgVoorkantId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IDImages",
                columns: table => new
                {
                    IDImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDImages", x => x.IDImageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ImgAchterkantId",
                table: "Patients",
                column: "ImgAchterkantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_IDImages_ImgAchterkantId",
                table: "Patients",
                column: "ImgAchterkantId",
                principalTable: "IDImages",
                principalColumn: "IDImageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_IDImages_ImgAchterkantId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "IDImages");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ImgAchterkantId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ImgAchterkantId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ImgVoorkantId",
                table: "Patients");
        }
    }
}
