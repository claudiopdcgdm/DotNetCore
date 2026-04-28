using Microsoft.EntityFrameworkCore.Migrations;

namespace Proeventos.Persistence.Migrations
{
    public partial class InsertOnModelCreatingContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PalestrantesEventos",
                table: "PalestrantesEventos");

            migrationBuilder.DropIndex(
                name: "IX_PalestrantesEventos_EventoId",
                table: "PalestrantesEventos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PalestrantesEventos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PalestrantesEventos",
                table: "PalestrantesEventos",
                columns: new[] { "EventoId", "PalestranteId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PalestrantesEventos",
                table: "PalestrantesEventos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PalestrantesEventos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PalestrantesEventos",
                table: "PalestrantesEventos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PalestrantesEventos_EventoId",
                table: "PalestrantesEventos",
                column: "EventoId");
        }
    }
}
