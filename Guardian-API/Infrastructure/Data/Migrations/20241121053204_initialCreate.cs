using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guardian_API.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FALHA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Prioridade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EquipeManutencaoResponsavel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataResolucao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FALHA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_LOCALIZACAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Regiao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pais = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOCALIZACAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PARQUE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AnoInauguracao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AreaKm = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Tecnologia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StatusOperacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumeroAerogeradores = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PARQUE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PARQUE_TB_LOCALIZACAO_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "TB_LOCALIZACAO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_TORRE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DataInstalacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    StatusOperacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UltimaLeitura = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TORRE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TORRE_TB_LOCALIZACAO_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "TB_LOCALIZACAO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_AEROGERADOR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tecnologia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CapacidadeMW = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    AlturaMastro = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    VelocidadeCorte = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    StatusOperacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DiametroMotor = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Garantia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FalhaEntityId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ParqueEntityId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AEROGERADOR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_AEROGERADOR_TB_FALHA_FalhaEntityId",
                        column: x => x.FalhaEntityId,
                        principalTable: "TB_FALHA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_AEROGERADOR_TB_PARQUE_ParqueEntityId",
                        column: x => x.ParqueEntityId,
                        principalTable: "TB_PARQUE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_AEROGERADOR_FalhaEntityId",
                table: "TB_AEROGERADOR",
                column: "FalhaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AEROGERADOR_ParqueEntityId",
                table: "TB_AEROGERADOR",
                column: "ParqueEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARQUE_LocalizacaoId",
                table: "TB_PARQUE",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TORRE_LocalizacaoId",
                table: "TB_TORRE",
                column: "LocalizacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_AEROGERADOR");

            migrationBuilder.DropTable(
                name: "TB_TORRE");

            migrationBuilder.DropTable(
                name: "TB_FALHA");

            migrationBuilder.DropTable(
                name: "TB_PARQUE");

            migrationBuilder.DropTable(
                name: "TB_LOCALIZACAO");
        }
    }
}
