using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace aspent.Migrations
{
    public partial class FirstModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDePessoa = table.Column<string>(type: "text", nullable: true),
                    Atividade = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroReserva = table.Column<string>(type: "text", nullable: true),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    rg = table.Column<string>(type: "text", nullable: true),
                    nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ParceiroId = table.Column<int>(type: "integer", nullable: true),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "text", nullable: true),
                    Fundacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Parceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FisicaReservaHotel",
                columns: table => new
                {
                    FisicaId = table.Column<int>(type: "integer", nullable: false),
                    ReservaHotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisicaReservaHotel", x => new { x.FisicaId, x.ReservaHotelId });
                    table.ForeignKey(
                        name: "FK_FisicaReservaHotel_Pessoa_FisicaId",
                        column: x => x.FisicaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FisicaReservaHotel_ReservaHotel_ReservaHotelId",
                        column: x => x.ReservaHotelId,
                        principalTable: "ReservaHotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuridicaParceiro",
                columns: table => new
                {
                    JuridicaId = table.Column<int>(type: "integer", nullable: false),
                    ParceiroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridicaParceiro", x => new { x.JuridicaId, x.ParceiroId });
                    table.ForeignKey(
                        name: "FK_JuridicaParceiro_Parceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridicaParceiro_Pessoa_JuridicaId",
                        column: x => x.JuridicaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FisicaReservaHotel_ReservaHotelId",
                table: "FisicaReservaHotel",
                column: "ReservaHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridicaParceiro_ParceiroId",
                table: "JuridicaParceiro",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ParceiroId",
                table: "Pessoa",
                column: "ParceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FisicaReservaHotel");

            migrationBuilder.DropTable(
                name: "JuridicaParceiro");

            migrationBuilder.DropTable(
                name: "ReservaHotel");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Parceiro");
        }
    }
}
