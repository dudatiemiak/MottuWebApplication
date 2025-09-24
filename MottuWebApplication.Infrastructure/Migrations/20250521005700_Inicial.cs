using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuWebApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmDepartamento = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DsDepartamento = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    IdModelo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmModelo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.IdModelo);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmPais = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmEstado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdPais = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    IdCidade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmCidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    IdEstado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.IdCidade);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bairros",
                columns: table => new
                {
                    IdBairro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmBairro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdCidade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairros", x => x.IdBairro);
                    table.ForeignKey(
                        name: "FK_Bairros_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "IdCidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logradouros",
                columns: table => new
                {
                    IdLogradouro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmLogradouro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NrLogradouro = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    NmComplemento = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdBairro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logradouros", x => x.IdLogradouro);
                    table.ForeignKey(
                        name: "FK_Logradouros_Bairros_IdBairro",
                        column: x => x.IdBairro,
                        principalTable: "Bairros",
                        principalColumn: "IdBairro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmCliente = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NrCpf = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    NmEmail = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdLogradouro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Logradouros_IdLogradouro",
                        column: x => x.IdLogradouro,
                        principalTable: "Logradouros",
                        principalColumn: "IdLogradouro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    IdFilial = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmFilial = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdLogradouro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.IdFilial);
                    table.ForeignKey(
                        name: "FK_Filiais_Logradouros_IdLogradouro",
                        column: x => x.IdLogradouro,
                        principalTable: "Logradouros",
                        principalColumn: "IdLogradouro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilialDepartamentos",
                columns: table => new
                {
                    IdFilialDepartamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdFilial = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdDepartamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DtEntrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DtSaida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilialDepartamentos", x => x.IdFilialDepartamento);
                    table.ForeignKey(
                        name: "FK_FilialDepartamentos_Departamentos_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilialDepartamentos_Filiais_IdFilial",
                        column: x => x.IdFilial,
                        principalTable: "Filiais",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmFuncionario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NmCargo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    NmEmailCorporativo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NmSenha = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    IdFilial = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Filiais_IdFilial",
                        column: x => x.IdFilial,
                        principalTable: "Filiais",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    IdMoto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmPlaca = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    StMoto = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    KmRodado = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    IdCliente = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdModelo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdFilialDepartamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.IdMoto);
                    table.ForeignKey(
                        name: "FK_Motos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motos_FilialDepartamentos_IdFilialDepartamento",
                        column: x => x.IdFilialDepartamento,
                        principalTable: "FilialDepartamentos",
                        principalColumn: "IdFilialDepartamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motos_Modelos_IdModelo",
                        column: x => x.IdModelo,
                        principalTable: "Modelos",
                        principalColumn: "IdModelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    IdManutencao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtEntrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DtSaida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DsManutencao = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false),
                    IdMoto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.IdManutencao);
                    table.ForeignKey(
                        name: "FK_Manutencoes_Motos_IdMoto",
                        column: x => x.IdMoto,
                        principalTable: "Motos",
                        principalColumn: "IdMoto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_IdCidade",
                table: "Bairros",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_IdEstado",
                table: "Cidades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdLogradouro",
                table: "Clientes",
                column: "IdLogradouro");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdPais",
                table: "Estados",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_IdLogradouro",
                table: "Filiais",
                column: "IdLogradouro");

            migrationBuilder.CreateIndex(
                name: "IX_FilialDepartamentos_IdDepartamento",
                table: "FilialDepartamentos",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_FilialDepartamentos_IdFilial",
                table: "FilialDepartamentos",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdFilial",
                table: "Funcionarios",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Logradouros_IdBairro",
                table: "Logradouros",
                column: "IdBairro");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_IdMoto",
                table: "Manutencoes",
                column: "IdMoto");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_IdCliente",
                table: "Motos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_IdFilialDepartamento",
                table: "Motos",
                column: "IdFilialDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_IdModelo",
                table: "Motos",
                column: "IdModelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "FilialDepartamentos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropTable(
                name: "Logradouros");

            migrationBuilder.DropTable(
                name: "Bairros");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
