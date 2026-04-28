using Microsoft.EntityFrameworkCore.Migrations;

namespace Proeventos.Persistence.Migrations
{
    public partial class onDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocias_Eventos_EventoId",
                table: "RedesSocias");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocias_Palestrante_PalestranteId",
                table: "RedesSocias");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocias_Eventos_EventoId",
                table: "RedesSocias",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocias_Palestrante_PalestranteId",
                table: "RedesSocias",
                column: "PalestranteId",
                principalTable: "Palestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocias_Eventos_EventoId",
                table: "RedesSocias");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocias_Palestrante_PalestranteId",
                table: "RedesSocias");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocias_Eventos_EventoId",
                table: "RedesSocias",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocias_Palestrante_PalestranteId",
                table: "RedesSocias",
                column: "PalestranteId",
                principalTable: "Palestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
