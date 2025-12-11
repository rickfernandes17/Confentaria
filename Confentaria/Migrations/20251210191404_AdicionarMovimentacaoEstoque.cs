using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confentaria.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarMovimentacaoEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentacoesEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    QuantidadeAnterior = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    QuantidadeNova = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NotaFiscalId = table.Column<int>(type: "int", nullable: true),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacoesEstoque_NotasFiscais_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotasFiscais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovimentacoesEstoque_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesEstoque_NotaFiscalId",
                table: "MovimentacoesEstoque",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesEstoque_ProdutoId",
                table: "MovimentacoesEstoque",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacoesEstoque");
        }
    }
}
