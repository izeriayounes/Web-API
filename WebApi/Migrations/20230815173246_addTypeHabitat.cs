using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addTypeHabitat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeHabitatId",
                table: "Familles");

            migrationBuilder.AddColumn<string>(
                name: "TypeHabitat",
                table: "Familles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeHabitat",
                table: "Familles");

            migrationBuilder.AddColumn<int>(
                name: "TypeHabitatId",
                table: "Familles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
