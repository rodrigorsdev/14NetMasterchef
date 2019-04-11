using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Masterchef.Web.Migrations.Masterchef
{
    public partial class AdicionadoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rendimento",
                table: "Receita");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Receita",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Receita",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Receita",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CascadeMode = table.Column<int>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receita_CategoriaId",
                table: "Receita",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Categoria_CategoriaId",
                table: "Receita",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Categoria_CategoriaId",
                table: "Receita");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Receita_CategoriaId",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Receita");

            migrationBuilder.AddColumn<int>(
                name: "Rendimento",
                table: "Receita",
                nullable: false,
                defaultValue: 0);
        }
    }
}
