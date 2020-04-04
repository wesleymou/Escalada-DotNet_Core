using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Escalada.Migrations
{
    public partial class Version002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "events");

            migrationBuilder.AddColumn<int>(
                name: "statusid",
                table: "events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "eventstatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventstatus", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_statusid",
                table: "events",
                column: "statusid");

            migrationBuilder.AddForeignKey(
                name: "FK_events_eventstatus_statusid",
                table: "events",
                column: "statusid",
                principalTable: "eventstatus",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_eventstatus_statusid",
                table: "events");

            migrationBuilder.DropTable(
                name: "eventstatus");

            migrationBuilder.DropIndex(
                name: "IX_events_statusid",
                table: "events");

            migrationBuilder.DropColumn(
                name: "statusid",
                table: "events");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "events",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
