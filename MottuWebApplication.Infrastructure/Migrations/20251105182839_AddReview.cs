using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuWebApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bairros_Cidades_IdCidade",
                table: "Bairros");

            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_IdEstado",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Logradouros_IdLogradouro",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Paises_IdPais",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Logradouros_IdLogradouro",
                table: "Filiais");

            migrationBuilder.DropForeignKey(
                name: "FK_FilialDepartamentos_Departamentos_IdDepartamento",
                table: "FilialDepartamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_FilialDepartamentos_Filiais_IdFilial",
                table: "FilialDepartamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Filiais_IdFilial",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Logradouros_Bairros_IdBairro",
                table: "Logradouros");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencoes_Motos_IdMoto",
                table: "Manutencoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Clientes_IdCliente",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_FilialDepartamentos_IdFilialDepartamento",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Modelos_IdModelo",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_IdCliente",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_IdFilialDepartamento",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_IdModelo",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Manutencoes_IdMoto",
                table: "Manutencoes");

            migrationBuilder.DropIndex(
                name: "IX_Logradouros_IdBairro",
                table: "Logradouros");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_IdFilial",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_FilialDepartamentos_IdDepartamento",
                table: "FilialDepartamentos");

            migrationBuilder.DropIndex(
                name: "IX_FilialDepartamentos_IdFilial",
                table: "FilialDepartamentos");

            migrationBuilder.DropIndex(
                name: "IX_Filiais_IdLogradouro",
                table: "Filiais");

            migrationBuilder.DropIndex(
                name: "IX_Estados_IdPais",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdLogradouro",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_IdEstado",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Bairros_IdCidade",
                table: "Bairros");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    KmRodados = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    DiasDesdeUltimaManutencao = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    PredictedManutencao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ManutencaoScore = table.Column<float>(type: "BINARY_FLOAT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

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

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_IdMoto",
                table: "Manutencoes",
                column: "IdMoto");

            migrationBuilder.CreateIndex(
                name: "IX_Logradouros_IdBairro",
                table: "Logradouros",
                column: "IdBairro");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdFilial",
                table: "Funcionarios",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_FilialDepartamentos_IdDepartamento",
                table: "FilialDepartamentos",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_FilialDepartamentos_IdFilial",
                table: "FilialDepartamentos",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_IdLogradouro",
                table: "Filiais",
                column: "IdLogradouro");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdPais",
                table: "Estados",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdLogradouro",
                table: "Clientes",
                column: "IdLogradouro");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_IdEstado",
                table: "Cidades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_IdCidade",
                table: "Bairros",
                column: "IdCidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Bairros_Cidades_IdCidade",
                table: "Bairros",
                column: "IdCidade",
                principalTable: "Cidades",
                principalColumn: "IdCidade",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_IdEstado",
                table: "Cidades",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Logradouros_IdLogradouro",
                table: "Clientes",
                column: "IdLogradouro",
                principalTable: "Logradouros",
                principalColumn: "IdLogradouro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Paises_IdPais",
                table: "Estados",
                column: "IdPais",
                principalTable: "Paises",
                principalColumn: "IdPais",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Logradouros_IdLogradouro",
                table: "Filiais",
                column: "IdLogradouro",
                principalTable: "Logradouros",
                principalColumn: "IdLogradouro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilialDepartamentos_Departamentos_IdDepartamento",
                table: "FilialDepartamentos",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilialDepartamentos_Filiais_IdFilial",
                table: "FilialDepartamentos",
                column: "IdFilial",
                principalTable: "Filiais",
                principalColumn: "IdFilial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Filiais_IdFilial",
                table: "Funcionarios",
                column: "IdFilial",
                principalTable: "Filiais",
                principalColumn: "IdFilial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logradouros_Bairros_IdBairro",
                table: "Logradouros",
                column: "IdBairro",
                principalTable: "Bairros",
                principalColumn: "IdBairro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencoes_Motos_IdMoto",
                table: "Manutencoes",
                column: "IdMoto",
                principalTable: "Motos",
                principalColumn: "IdMoto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Clientes_IdCliente",
                table: "Motos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_FilialDepartamentos_IdFilialDepartamento",
                table: "Motos",
                column: "IdFilialDepartamento",
                principalTable: "FilialDepartamentos",
                principalColumn: "IdFilialDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Modelos_IdModelo",
                table: "Motos",
                column: "IdModelo",
                principalTable: "Modelos",
                principalColumn: "IdModelo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
