using Microsoft.EntityFrameworkCore.Migrations;
using System.Data;

#nullable disable

namespace GerenciadorDeEstufasAPI.Migrations
{
    public partial class AtualizandoEntidadeAmostra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAmostra",
                table: "Amostras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "Amostras_Id",
                table: "Amostras",
                column:"IdAmostra",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAmostra",
                table: "Amostras");
        }
    }
}
