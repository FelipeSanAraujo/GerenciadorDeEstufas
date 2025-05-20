using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeEstufasAPI.Migrations
{
    public partial class MelhorandoAmostras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Amostras_IdAmostra",
                table: "Amostras",
                column: "IdAmostra",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Amostras_IdAmostra",
                table: "Amostras");
        }
    }
}
