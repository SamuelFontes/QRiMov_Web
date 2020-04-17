using Microsoft.EntityFrameworkCore.Migrations;

namespace QRiMov_Web.Migrations
{
    public partial class Dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CATEGORIAS VALUES ('NOME','Descricao')");
            migrationBuilder.Sql("INSERT INTO LANCHES VALUES ('Nome do lanche','Descrição curta','Descrição Detalhada',1.2," +
                "'https://emc.acidadeon.com/dbimagens/lanches_como_790x505_06032018153232.jpg'," +
                "'https://emc.acidadeon.com/dbimagens/lanches_como_790x505_06032018153232.jpg',1,1,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CATEGORIAS ");
            migrationBuilder.Sql("DELETE FROM LANCHES ");
        }
    }
}
