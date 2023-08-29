using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class nullableFam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants");

            migrationBuilder.AlterColumn<int>(
                name: "FamilleId",
                table: "Enfants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants",
                column: "FamilleId",
                principalTable: "Familles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants");

            migrationBuilder.AlterColumn<int>(
                name: "FamilleId",
                table: "Enfants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enfants_Familles_FamilleId",
                table: "Enfants",
                column: "FamilleId",
                principalTable: "Familles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
