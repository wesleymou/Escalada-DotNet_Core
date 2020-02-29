using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace escalada.Migrations
{
    public partial class Version002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscriptionProviders");

            migrationBuilder.DropTable(
                name: "subscriptionsInEvents");

            migrationBuilder.CreateTable(
                name: "agreement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    providerIdid = table.Column<int>(nullable: true),
                    Eventid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agreement", x => x.id);
                    table.ForeignKey(
                        name: "FK_agreement_events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_agreement_providers_providerIdid",
                        column: x => x.providerIdid,
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
                    valorTotal = table.Column<decimal>(nullable: false),
                    valorRecebido = table.Column<decimal>(nullable: false),
                    tipoPagamentoIdid = table.Column<int>(nullable: true),
                    Customerid = table.Column<int>(nullable: true),
                    Eventid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscription", x => x.id);
                    table.ForeignKey(
                        name: "FK_inscription_customers_Customerid",
                        column: x => x.Customerid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inscription_events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inscription_paymentTypes_tipoPagamentoIdid",
                        column: x => x.tipoPagamentoIdid,
                        principalTable: "paymentTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agreement_Eventid",
                table: "agreement",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_agreement_providerIdid",
                table: "agreement",
                column: "providerIdid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_Customerid",
                table: "inscription",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_Eventid",
                table: "inscription",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_tipoPagamentoIdid",
                table: "inscription",
                column: "tipoPagamentoIdid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agreement");

            migrationBuilder.DropTable(
                name: "inscription");

            migrationBuilder.CreateTable(
                name: "subscriptionProviders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eventid = table.Column<int>(type: "integer", nullable: true),
                    providerIdid = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "subscriptionsInEvents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Customerid = table.Column<int>(type: "integer", nullable: true),
                    Eventid = table.Column<int>(type: "integer", nullable: true),
                    tipoPagamentoIdid = table.Column<int>(type: "integer", nullable: true),
                    valorRecebido = table.Column<decimal>(type: "numeric", nullable: false),
                    valorTotal = table.Column<decimal>(type: "numeric", nullable: false)
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
    }
}
