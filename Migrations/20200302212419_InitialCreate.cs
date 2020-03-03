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
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymenttypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<int>(nullable: false)
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inscription",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    valortotal = table.Column<decimal>(nullable: false),
                    valorrecebido = table.Column<decimal>(nullable: false),
                    tipopagamentoid = table.Column<int>(nullable: true),
                    customerid = table.Column<int>(nullable: true),
                    eventid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscription", x => x.id);
                    table.ForeignKey(
                        name: "FK_inscription_customers_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inscription_events_eventid",
                        column: x => x.eventid,
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

            migrationBuilder.CreateIndex(
                name: "IX_agreement_eventid",
                table: "agreement",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_agreement_providerid",
                table: "agreement",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_customerid",
                table: "inscription",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_eventid",
                table: "inscription",
                column: "eventid");

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
                name: "users");

            migrationBuilder.DropTable(
                name: "providers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "paymenttypes");
        }
    }
}
