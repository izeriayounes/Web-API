using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Runtime.Intrinsics.X86;
using WebApi.Models;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddDateCreatedToParrainages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
            name: "dateCreated",
            table: "parrainages",
            nullable: false,
            defaultValueSql: "GETDATE()"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "dateCreated",
               table: "parrainages");
        }
    }
}
