using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RO.DevTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVendaAndProdutoVendido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoVendido_Produtos_ProdutoId",
                table: "ProdutoVendido");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoVendido_Venda_VendaId",
                table: "ProdutoVendido");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Clientes_ClienteId",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venda",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoVendido",
                table: "ProdutoVendido");

            migrationBuilder.RenameTable(
                name: "Venda",
                newName: "Vendas");

            migrationBuilder.RenameTable(
                name: "ProdutoVendido",
                newName: "ProdutosVendidos");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ClienteId",
                table: "Vendas",
                newName: "IX_Vendas_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoVendido_VendaId",
                table: "ProdutosVendidos",
                newName: "IX_ProdutosVendidos_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoVendido_ProdutoId",
                table: "ProdutosVendidos",
                newName: "IX_ProdutosVendidos_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosVendidos",
                table: "ProdutosVendidos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosVendidos_Produtos_ProdutoId",
                table: "ProdutosVendidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosVendidos_Vendas_VendaId",
                table: "ProdutosVendidos",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosVendidos_Produtos_ProdutoId",
                table: "ProdutosVendidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosVendidos_Vendas_VendaId",
                table: "ProdutosVendidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosVendidos",
                table: "ProdutosVendidos");

            migrationBuilder.RenameTable(
                name: "Vendas",
                newName: "Venda");

            migrationBuilder.RenameTable(
                name: "ProdutosVendidos",
                newName: "ProdutoVendido");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_ClienteId",
                table: "Venda",
                newName: "IX_Venda_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosVendidos_VendaId",
                table: "ProdutoVendido",
                newName: "IX_ProdutoVendido_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosVendidos_ProdutoId",
                table: "ProdutoVendido",
                newName: "IX_ProdutoVendido_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venda",
                table: "Venda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoVendido",
                table: "ProdutoVendido",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoVendido_Produtos_ProdutoId",
                table: "ProdutoVendido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoVendido_Venda_VendaId",
                table: "ProdutoVendido",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Clientes_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
