using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CancellationTokenDemo.Migrations
{
    public partial class AdicionadoColunaIdNasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Tabela2",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Tabela1",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tabela2",
                table: "Tabela2",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tabela1",
                table: "Tabela1",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tabela2",
                table: "Tabela2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tabela1",
                table: "Tabela1");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Tabela2");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Tabela1");
        }
    }
}
