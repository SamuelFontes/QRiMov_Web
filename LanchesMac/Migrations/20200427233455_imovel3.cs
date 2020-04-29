using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LanchesMac.Migrations
{
    public partial class imovel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Lanches_Categorias_CategoriaId",
                table: "Lanches");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhes_Lanches_LancheId",
                table: "PedidoDetalhes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lanches",
                table: "Lanches");

            migrationBuilder.RenameTable(
                name: "Lanches",
                newName: "Imóvel");

            migrationBuilder.RenameIndex(
                name: "IX_Lanches_CategoriaId",
                table: "Imóvel",
                newName: "IX_Imóvel_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imóvel",
                table: "Imóvel",
                column: "LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Imóvel_LancheId",
                table: "CarrinhoCompraItens",
                column: "LancheId",
                principalTable: "Imóvel",
                principalColumn: "LancheId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imóvel_Categorias_CategoriaId",
                table: "Imóvel",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhes_Imóvel_LancheId",
                table: "PedidoDetalhes",
                column: "LancheId",
                principalTable: "Imóvel",
                principalColumn: "LancheId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Imóvel_LancheId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Imóvel_Categorias_CategoriaId",
                table: "Imóvel");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhes_Imóvel_LancheId",
                table: "PedidoDetalhes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imóvel",
                table: "Imóvel");

            migrationBuilder.RenameTable(
                name: "Imóvel",
                newName: "Lanches");

            migrationBuilder.RenameIndex(
                name: "IX_Imóvel_CategoriaId",
                table: "Lanches",
                newName: "IX_Lanches_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lanches",
                table: "Lanches",
                column: "LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lanches_Categorias_CategoriaId",
                table: "Lanches",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhes_Lanches_LancheId",
                table: "PedidoDetalhes",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
