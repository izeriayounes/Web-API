using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants");

            migrationBuilder.DropIndex(
                name: "IX_Enfants_FamilleId",
                table: "Enfants");

            migrationBuilder.DropColumn(
                name: "FamilleId",
                table: "Enfants");

            migrationBuilder.AddColumn<int>(
                name: "FamillesId",
                table: "Enfants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_FamillesId",
                table: "Enfants",
                column: "FamillesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfants_Familles_FamillesId",
                table: "Enfants",
                column: "FamillesId",
                principalTable: "Familles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfants_Familles_FamillesId",
                table: "Enfants");

            migrationBuilder.DropIndex(
                name: "IX_Enfants_FamillesId",
                table: "Enfants");

            migrationBuilder.DropColumn(
                name: "FamillesId",
                table: "Enfants");

            migrationBuilder.AddColumn<int>(
                name: "FamilleId",
                table: "Enfants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_FamilleId",
                table: "Enfants",
                column: "FamilleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants",
                column: "FamilleId",
                principalTable: "Familles",
                principalColumn: "Id");
        }
    }
}
