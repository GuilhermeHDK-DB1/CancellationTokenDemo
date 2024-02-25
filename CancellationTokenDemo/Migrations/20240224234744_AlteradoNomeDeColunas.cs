using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CancellationTokenDemo.Migrations
{
    public partial class AlteradoNomeDeColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantidade_conta",
                table: "Tabela2",
                newName: "quantidade_finalizada");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Tabela1",
                newName: "produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantidade_finalizada",
                table: "Tabela2",
                newName: "quantidade_conta");

            migrationBuilder.RenameColumn(
                name: "produto",
                table: "Tabela1",
                newName: "username");
        }
    }
}
