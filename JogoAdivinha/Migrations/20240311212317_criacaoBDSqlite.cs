using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoAdivinha.Migrations
{
    public partial class criacaoBDSqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    COD_JOGADOR = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NUM_TENTATIVA = table.Column<int>(type: "INTEGER", nullable: false),
                    Tentativa = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RESULTADO = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.COD_JOGADOR);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historicos");
        }
    }
}
