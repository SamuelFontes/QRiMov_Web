using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QRiMovWeb.Migrations
{
    public partial class detalhes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalhes",
                table: "Imoveis",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalhes",
                table: "Imoveis");
        }
    }
}
