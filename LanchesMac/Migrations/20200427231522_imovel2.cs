using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LanchesMac.Migrations
{
    public partial class imovel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    ImovelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaId = table.Column<int>(nullable: false),
                    DescricaoCurta = table.Column<string>(maxLength: 200, nullable: false),
                    DescricaoDetalhada = table.Column<string>(maxLength: 200, nullable: false),
                    EmEstoque = table.Column<bool>(nullable: false),
                    ImagemThumbnailUrl = table.Column<string>(maxLength: 200, nullable: true),
                    ImagemUrl = table.Column<string>(maxLength: 200, nullable: true),
                    IsLanchePreferido = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.ImovelId);
                    table.ForeignKey(
                        name: "FK_Imoveis_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imoveis");
        }
    }
}
