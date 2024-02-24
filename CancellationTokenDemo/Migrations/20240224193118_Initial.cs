using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CancellationTokenDemo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabela1",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Tabela2",
                columns: table => new
                {
                    quantidade_conta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabela1");

            migrationBuilder.DropTable(
                name: "Tabela2");
        }
    }
}
