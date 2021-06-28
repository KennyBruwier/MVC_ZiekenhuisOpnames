using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_ZiekenhuisOpnames.Migrations
{
    public partial class AddImageTableWithoutCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_IDImages_ImgAchterkantId",
                table: "Patients");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_IDImages_ImgAchterkantId",
                table: "Patients",
                column: "ImgAchterkantId",
                principalTable: "IDImages",
                principalColumn: "IDImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_IDImages_ImgAchterkantId",
                table: "Patients");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_IDImages_ImgAchterkantId",
                table: "Patients",
                column: "ImgAchterkantId",
                principalTable: "IDImages",
                principalColumn: "IDImageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
