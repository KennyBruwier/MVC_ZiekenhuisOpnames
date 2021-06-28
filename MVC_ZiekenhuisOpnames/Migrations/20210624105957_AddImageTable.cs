using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_ZiekenhuisOpnames.Migrations
{
    public partial class AddImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patients_ImgVoorkantId",
                table: "Patients",
                column: "ImgVoorkantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_IDImages_ImgVoorkantId",
                table: "Patients",
                column: "ImgVoorkantId",
                principalTable: "IDImages",
                principalColumn: "IDImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_IDImages_ImgVoorkantId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ImgVoorkantId",
                table: "Patients");
        }
    }
}
