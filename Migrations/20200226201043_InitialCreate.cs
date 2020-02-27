using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace escalada.Migrations
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
                    cpf = table.Column<long[]>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    numFone1 = table.Column<long[]>(nullable: true),
                    numFone2 = table.Column<long[]>(nullable: true),
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
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataTermino = table.Column<DateTime>(nullable: false),
                    local = table.Column<string>(nullable: true),
                    capacidade = table.Column<long>(nullable: false),
                    quorum = table.Column<long>(nullable: false),
                    orcamentoPrevio = table.Column<decimal>(nullable: false),
                    valorIngresso = table.Column<decimal>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymentTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "providers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscriptionsInEvents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    valorTotal = table.Column<decimal>(nullable: false),
                    valorRecebido = table.Column<decimal>(nullable: false),
                    tipoPagamentoIdid = table.Column<int>(nullable: true),
                    Customerid = table.Column<int>(nullable: true),
                    Eventid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptionsInEvents", x => x.id);
                    table.ForeignKey(
                        name: "FK_subscriptionsInEvents_customers_Customerid",
                        column: x => x.Customerid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subscriptionsInEvents_events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subscriptionsInEvents_paymentTypes_tipoPagamentoIdid",
                        column: x => x.tipoPagamentoIdid,
                        principalTable: "paymentTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subscriptionProviders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    providerIdid = table.Column<int>(nullable: true),
                    Eventid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptionProviders", x => x.id);
                    table.ForeignKey(
                        name: "FK_subscriptionProviders_events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subscriptionProviders_providers_providerIdid",
                        column: x => x.providerIdid,
                        principalTable: "providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscriptionProviders_Eventid",
                table: "subscriptionProviders",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptionProviders_providerIdid",
                table: "subscriptionProviders",
                column: "providerIdid");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptionsInEvents_Customerid",
                table: "subscriptionsInEvents",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptionsInEvents_Eventid",
                table: "subscriptionsInEvents",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptionsInEvents_tipoPagamentoIdid",
                table: "subscriptionsInEvents",
                column: "tipoPagamentoIdid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscriptionProviders");

            migrationBuilder.DropTable(
                name: "subscriptionsInEvents");

            migrationBuilder.DropTable(
                name: "providers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "paymentTypes");
        }
    }
}
