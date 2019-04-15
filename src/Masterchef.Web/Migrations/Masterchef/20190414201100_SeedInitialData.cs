using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Masterchef.Web.Migrations.Masterchef
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "AddDate", "CascadeMode", "Descricao", "Nome", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("57e7515e-8285-43e6-b6c0-ec7b9890a879"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Bolos", "Bolos", null },
                    { new Guid("ef659695-a1f8-4740-a974-8e563a9e12bd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Tortas", "Tortas", null },
                    { new Guid("c7985033-24b1-4cca-84d9-0face1199031"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Carnes", "Carnes", null },
                    { new Guid("4f31f332-5a04-4bde-a999-ad0f8ac728e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Aves", "Aves", null },
                    { new Guid("34890e59-8e05-4628-9060-478cd9d98193"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Massas", "Massas", null },
                    { new Guid("1bf37d85-67d2-4c5f-9438-b78e67f0b678"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sopas e caldos", "Sopas e caldos", null },
                    { new Guid("d163b2d8-8ec0-4f03-8c66-0344d8a10910"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Doces", "Doces", null }
                });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "AddDate", "CascadeMode", "Nome", "UnidadeMedida", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("eb33f88a-9cf3-4d0b-b762-70f0457ad356"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Farinha de trigo", "kg", null },
                    { new Guid("250b697b-18cb-4c4b-987a-53ce663b7fb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ovo", "un", null },
                    { new Guid("27166bba-148f-4082-91ee-bcec547390ed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Leite", "ml", null },
                    { new Guid("f994d309-212f-4f9c-8672-6c964ab7b516"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sal", "colher chá", null },
                    { new Guid("56e6d958-cb88-4315-8356-73a1f831f872"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Açucar", "colher sopa", null },
                    { new Guid("8369d249-dcdd-4ba6-85b4-8d0955580163"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Óleo", "Xicara", null },
                    { new Guid("8974aefa-e989-4027-9e04-d1e1a96a206c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Água", "ml", null },
                    { new Guid("df6badb5-159d-42c7-925b-6508c8cecaea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Leite em pó", "colher sopa", null },
                    { new Guid("07fa9f48-adbc-47e1-97dc-b6883b300471"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Amido de milho", "colher sopa", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("1bf37d85-67d2-4c5f-9438-b78e67f0b678"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("34890e59-8e05-4628-9060-478cd9d98193"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("4f31f332-5a04-4bde-a999-ad0f8ac728e2"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("57e7515e-8285-43e6-b6c0-ec7b9890a879"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("c7985033-24b1-4cca-84d9-0face1199031"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("d163b2d8-8ec0-4f03-8c66-0344d8a10910"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("ef659695-a1f8-4740-a974-8e563a9e12bd"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("07fa9f48-adbc-47e1-97dc-b6883b300471"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("250b697b-18cb-4c4b-987a-53ce663b7fb5"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("27166bba-148f-4082-91ee-bcec547390ed"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("56e6d958-cb88-4315-8356-73a1f831f872"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("8369d249-dcdd-4ba6-85b4-8d0955580163"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("8974aefa-e989-4027-9e04-d1e1a96a206c"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("df6badb5-159d-42c7-925b-6508c8cecaea"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("eb33f88a-9cf3-4d0b-b762-70f0457ad356"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: new Guid("f994d309-212f-4f9c-8672-6c964ab7b516"));
        }
    }
}
