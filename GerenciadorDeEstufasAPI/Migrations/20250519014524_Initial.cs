using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeEstufasAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estufas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroDeIdentificacao = table.Column<int>(type: "int", nullable: false),
                    NumeroDeAmostrasPorFileira = table.Column<int>(type: "int", nullable: false),
                    NumeroDeBandejas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estufas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amostras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFileira = table.Column<int>(type: "int", nullable: false),
                    NumeroBadeja = table.Column<int>(type: "int", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: false),
                    EstufaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amostras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amostras_Estufas_EstufaId",
                        column: x => x.EstufaId,
                        principalTable: "Estufas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amostras_EstufaId",
                table: "Amostras",
                column: "EstufaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amostras");

            migrationBuilder.DropTable(
                name: "Estufas");
        }
    }
}
