using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QRiMovWeb.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "CategoriaId");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Venda','Imóveis a venda')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Aluguel','Imóveis disponíveis para aluguel')");

            migrationBuilder.Sql("INSERT INTO Imoveis(Bairro,CEP,CategoriaId,Comarca,Complemento,Descricao,ImgMiniaturaUrl,ImgUrl,IsDestaque,Logradouro,Numero,UF,Valor,IsAtivo)" +
                " VALUES('Jardim Imperial','12950420',(SELECT CategoriaId FROM Categorias Where CategoriaNome='Venda'),'São Paulo','Em frente a árvore','Uma casa bacana','https://s2.glbimg.com/l5tf5ALrBpZgm6SyiYv55yoUlh0=/620x413/smart/e.glbimg.com/og/ed/f/original/2020/01/20/leve-e-iluminada-esta-casa-na-bahia-mistura-estrutura-metalica-madeira-e-vidro_9.jpg','https://s2.glbimg.com/l5tf5ALrBpZgm6SyiYv55yoUlh0=/620x413/smart/e.glbimg.com/og/ed/f/original/2020/01/20/leve-e-iluminada-esta-casa-na-bahia-mistura-estrutura-metalica-madeira-e-vidro_9.jpg',1,'Rua das figueiras','55','SP',629.12,1)");
            migrationBuilder.Sql("INSERT INTO Imoveis(Bairro,CEP,CategoriaId,Comarca,Complemento,Descricao,ImgMiniaturaUrl,ImgUrl,IsDestaque,Logradouro,Numero,UF,Valor,IsAtivo)" +
               " VALUES('Jardim Imperial','12950420',(SELECT CategoriaId FROM Categorias Where CategoriaNome='Venda'),'São Paulo','Em frente a árvore','Uma casa bacana','https://www.jfcimobiliaria.com.br/foto_/2020/6121/cravinhos-casa-condominio-rural-04-03-2020_17-13-55-8.jpg','https://www.jfcimobiliaria.com.br/foto_/2020/6121/cravinhos-casa-condominio-rural-04-03-2020_17-13-55-8.jpg',1,'Rua das figueiras','55','SP',629.12,1)");
            migrationBuilder.Sql("INSERT INTO Imoveis(Bairro,CEP,CategoriaId,Comarca,Complemento,Descricao,ImgMiniaturaUrl,ImgUrl,IsDestaque,Logradouro,Numero,UF,Valor,IsAtivo)" +
                           " VALUES('Jardim Imperial','12950420',(SELECT CategoriaId FROM Categorias Where CategoriaNome='Aluguel'),'São Paulo','Em frente a árvore','Uma casa bacana','https://i.ytimg.com/vi/95JILV-V4oc/maxresdefault.jpg','https://i.ytimg.com/vi/95JILV-V4oc/maxresdefault.jpg',1,'Rua das figueiras','55','SP',629.12,1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Imoveis");

        }
    }
}
