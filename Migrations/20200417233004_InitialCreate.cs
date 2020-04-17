using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Escalada.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpf = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    numfone1 = table.Column<string>(nullable: true),
                    numfone2 = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "paymenttypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymenttypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "providers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    datainicio = table.Column<DateTime>(nullable: false),
                    datatermino = table.Column<DateTime>(nullable: false),
                    local = table.Column<string>(nullable: true),
                    capacidade = table.Column<int>(nullable: false),
                    quorum = table.Column<int>(nullable: false),
                    orcamentoprevio = table.Column<decimal>(nullable: false),
                    valoringresso = table.Column<decimal>(nullable: false),
                    cronograma = table.Column<string>(nullable: true),
                    statusid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                    table.ForeignKey(
                        name: "FK_events_eventstatus_statusid",
                        column: x => x.statusid,
                        principalTable: "eventstatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agreement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    providerid = table.Column<int>(nullable: true),
                    eventid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agreement", x => x.id);
                    table.ForeignKey(
                        name: "FK_agreement_events_eventid",
                        column: x => x.eventid,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_agreement_providers_providerid",
                        column: x => x.providerid,
                        principalTable: "providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscription",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    qtdadulto = table.Column<int>(nullable: false),
                    qtdinfantil = table.Column<int>(nullable: false),
                    valortotal = table.Column<decimal>(nullable: false),
                    valorrecebido = table.Column<decimal>(nullable: false),
                    clienteid = table.Column<int>(nullable: true),
                    eventoid = table.Column<int>(nullable: true),
                    tipopagamentoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscription", x => x.id);
                    table.ForeignKey(
                        name: "FK_inscription_customers_clienteid",
                        column: x => x.clienteid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inscription_events_eventoid",
                        column: x => x.eventoid,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inscription_paymenttypes_tipopagamentoid",
                        column: x => x.tipopagamentoid,
                        principalTable: "paymenttypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agreement_eventid",
                table: "agreement",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_agreement_providerid",
                table: "agreement",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "IX_events_statusid",
                table: "events",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_clienteid",
                table: "inscription",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_eventoid",
                table: "inscription",
                column: "eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_tipopagamentoid",
                table: "inscription",
                column: "tipopagamentoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agreement");

            migrationBuilder.DropTable(
                name: "inscription");

            migrationBuilder.DropTable(
                name: "providers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "paymenttypes");

            migrationBuilder.DropTable(
                name: "eventstatus");
        }
    }
}
