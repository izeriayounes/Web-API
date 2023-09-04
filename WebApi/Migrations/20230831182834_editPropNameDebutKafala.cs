using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class editPropNameDebutKafala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DebutKafala",
                table: "Parrains",
                newName: "DateDebutKafala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateDebutKafala",
                table: "Parrains",
                newName: "DebutKafala");
        }
    }
}
