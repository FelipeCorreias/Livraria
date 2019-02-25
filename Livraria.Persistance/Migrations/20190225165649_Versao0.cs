using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Persistance.Migrations
{
    public partial class Versao0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    ISBN = table.Column<string>(nullable: false),
                    Autor = table.Column<string>(maxLength: 1500, nullable: true),
                    Nome = table.Column<string>(maxLength: 1500, nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Capa = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.ISBN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
