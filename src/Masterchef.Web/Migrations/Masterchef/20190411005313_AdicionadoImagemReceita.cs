using Microsoft.EntityFrameworkCore.Migrations;

namespace Masterchef.Web.Migrations.Masterchef
{
    public partial class AdicionadoImagemReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Receita",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Receita");
        }
    }
}
