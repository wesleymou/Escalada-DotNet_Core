using Microsoft.EntityFrameworkCore.Migrations;

namespace Escalada.Migrations
{
    public partial class Provider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Providers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Responsavel",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Providers");
        }
    }
}
