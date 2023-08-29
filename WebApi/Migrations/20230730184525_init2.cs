using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfants_Familles_FamillesId",
                table: "Enfants");

            migrationBuilder.RenameColumn(
                name: "FamillesId",
                table: "Enfants",
                newName: "FamilleId");

            migrationBuilder.RenameIndex(
                name: "IX_Enfants_FamillesId",
                table: "Enfants",
                newName: "IX_Enfants_FamilleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants",
                column: "FamilleId",
                principalTable: "Familles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants");

            migrationBuilder.RenameColumn(
                name: "FamilleId",
                table: "Enfants",
                newName: "FamillesId");

            migrationBuilder.RenameIndex(
                name: "IX_Enfants_FamilleId",
                table: "Enfants",
                newName: "IX_Enfants_FamillesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfants_Familles_FamillesId",
                table: "Enfants",
                column: "FamillesId",
                principalTable: "Familles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
