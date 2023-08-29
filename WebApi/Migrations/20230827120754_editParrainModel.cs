using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class editParrainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Parrains DROP COLUMN Fonction;");
            migrationBuilder.Sql("ALTER TABLE Parrains ADD Fonction NVARCHAR(MAX);");

            migrationBuilder.Sql("ALTER TABLE Parrains DROP COLUMN Adresse;");
            migrationBuilder.Sql("ALTER TABLE Parrains ADD Adresse NVARCHAR(MAX);");

            migrationBuilder.Sql("ALTER TABLE Parrains DROP COLUMN Email;");
            migrationBuilder.Sql("ALTER TABLE Parrains ADD Email NVARCHAR(MAX);");

            migrationBuilder.Sql("ALTER TABLE Parrains DROP COLUMN GSM;");
            migrationBuilder.Sql("ALTER TABLE Parrains ADD GSM NVARCHAR(MAX);");

            migrationBuilder.Sql("ALTER TABLE Parrains DROP COLUMN DebutKafala;");
            migrationBuilder.Sql("ALTER TABLE Parrains ADD DebutKafala datetime2;");

            migrationBuilder.Sql("ALTER TABLE Parrains DROP COLUMN DatePremiereCotisation;");
            migrationBuilder.Sql("ALTER TABLE Parrains ADD DatePremiereCotisation datetime2;");

            migrationBuilder.Sql("ALTER TABLE Parrains DROP COLUMN CotisationMensuelle;");
            migrationBuilder.Sql("ALTER TABLE Parrains ADD CotisationMensuelle NVARCHAR(MAX);");
            
            migrationBuilder.AlterColumn<string>(
                name: "GSM",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fonction",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DebutKafala",
                table: "Parrains",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePremiereCotisation",
                table: "Parrains",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CotisationMensuelle",
                table: "Parrains",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GSM",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fonction",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DebutKafala",
                table: "Parrains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePremiereCotisation",
                table: "Parrains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CotisationMensuelle",
                table: "Parrains",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Parrains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
