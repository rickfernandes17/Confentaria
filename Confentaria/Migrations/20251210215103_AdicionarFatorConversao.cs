using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confentaria.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarFatorConversao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FatorConversao",
                table: "FornecedorProdutos",
                type: "decimal(18,3)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatorConversao",
                table: "FornecedorProdutos");
        }
    }
}
