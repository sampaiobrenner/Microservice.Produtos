using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice.Produtos.WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaDoProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaDoProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoriaDoProdutoId = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    PrecoDeCusto = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    PrecoDeVenda = table.Column<decimal>(type: "decimal(5,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CategoriaDoProduto_CategoriaDoProdutoId",
                        column: x => x.CategoriaDoProdutoId,
                        principalTable: "CategoriaDoProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaDoProdutoId",
                table: "Produto",
                column: "CategoriaDoProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "CategoriaDoProduto");
        }
    }
}
