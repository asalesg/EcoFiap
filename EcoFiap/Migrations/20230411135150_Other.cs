using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoFiap.Migrations
{
    /// <inheritdoc />
    public partial class Other : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoModelAvaliacaoId",
                table: "USUARIO",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColetaModelColetaId",
                table: "USUARIO",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoModelAvaliacaoId",
                table: "COLETOR",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColetaModelColetaId",
                table: "COLETOR",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nota = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Coleta",
                columns: table => new
                {
                    ColetaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataHoraAgendada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coleta", x => x.ColetaId);
                });

            migrationBuilder.CreateTable(
                name: "Geolocalizacao",
                columns: table => new
                {
                    LocalizaçãoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Latitude = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Longitude = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UsuarioId1 = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ColetorId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geolocalizacao", x => x.LocalizaçãoId);
                    table.ForeignKey(
                        name: "FK_Geolocalizacao_COLETOR_ColetorId1",
                        column: x => x.ColetorId1,
                        principalTable: "COLETOR",
                        principalColumn: "COLETORID");
                    table.ForeignKey(
                        name: "FK_Geolocalizacao_USUARIO_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "USUARIO",
                        principalColumn: "USUARIOID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_AvaliacaoModelAvaliacaoId",
                table: "USUARIO",
                column: "AvaliacaoModelAvaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ColetaModelColetaId",
                table: "USUARIO",
                column: "ColetaModelColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_COLETOR_AvaliacaoModelAvaliacaoId",
                table: "COLETOR",
                column: "AvaliacaoModelAvaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_COLETOR_ColetaModelColetaId",
                table: "COLETOR",
                column: "ColetaModelColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Geolocalizacao_ColetorId1",
                table: "Geolocalizacao",
                column: "ColetorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Geolocalizacao_UsuarioId1",
                table: "Geolocalizacao",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_COLETOR_Avaliacao_AvaliacaoModelAvaliacaoId",
                table: "COLETOR",
                column: "AvaliacaoModelAvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_COLETOR_Coleta_ColetaModelColetaId",
                table: "COLETOR",
                column: "ColetaModelColetaId",
                principalTable: "Coleta",
                principalColumn: "ColetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIO_Avaliacao_AvaliacaoModelAvaliacaoId",
                table: "USUARIO",
                column: "AvaliacaoModelAvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIO_Coleta_ColetaModelColetaId",
                table: "USUARIO",
                column: "ColetaModelColetaId",
                principalTable: "Coleta",
                principalColumn: "ColetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COLETOR_Avaliacao_AvaliacaoModelAvaliacaoId",
                table: "COLETOR");

            migrationBuilder.DropForeignKey(
                name: "FK_COLETOR_Coleta_ColetaModelColetaId",
                table: "COLETOR");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_Avaliacao_AvaliacaoModelAvaliacaoId",
                table: "USUARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_Coleta_ColetaModelColetaId",
                table: "USUARIO");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Coleta");

            migrationBuilder.DropTable(
                name: "Geolocalizacao");

            migrationBuilder.DropIndex(
                name: "IX_USUARIO_AvaliacaoModelAvaliacaoId",
                table: "USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_USUARIO_ColetaModelColetaId",
                table: "USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_COLETOR_AvaliacaoModelAvaliacaoId",
                table: "COLETOR");

            migrationBuilder.DropIndex(
                name: "IX_COLETOR_ColetaModelColetaId",
                table: "COLETOR");

            migrationBuilder.DropColumn(
                name: "AvaliacaoModelAvaliacaoId",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "ColetaModelColetaId",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "AvaliacaoModelAvaliacaoId",
                table: "COLETOR");

            migrationBuilder.DropColumn(
                name: "ColetaModelColetaId",
                table: "COLETOR");
        }
    }
}
