using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proeventos.Persistence.Migrations
{
    public partial class AlterTableEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Eventos_EventoId",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PalestrantesEventos_Eventos_EventoId",
                table: "PalestrantesEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_PalestrantesEventos_Palestrante_PalestranteId",
                table: "PalestrantesEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocias_Eventos_EventoId",
                table: "RedesSocias");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocias_Palestrante_PalestranteId",
                table: "RedesSocias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedesSocias",
                table: "RedesSocias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PalestrantesEventos",
                table: "PalestrantesEventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Palestrante",
                table: "Palestrante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lotes",
                table: "Lotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.RenameTable(
                name: "RedesSocias",
                newName: "TbRedeSocial");

            migrationBuilder.RenameTable(
                name: "PalestrantesEventos",
                newName: "TbPalestraneEvento");

            migrationBuilder.RenameTable(
                name: "Palestrante",
                newName: "TbPalestrante");

            migrationBuilder.RenameTable(
                name: "Lotes",
                newName: "TbLote");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "TbEvento");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSocias_PalestranteId",
                table: "TbRedeSocial",
                newName: "IX_TbRedeSocial_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSocias_EventoId",
                table: "TbRedeSocial",
                newName: "IX_TbRedeSocial_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_PalestrantesEventos_PalestranteId",
                table: "TbPalestraneEvento",
                newName: "IX_TbPalestraneEvento_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_Lotes_EventoId",
                table: "TbLote",
                newName: "IX_TbLote_EventoId");

            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "TbEvento",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEvento",
                table: "TbEvento",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbRedeSocial",
                table: "TbRedeSocial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPalestraneEvento",
                table: "TbPalestraneEvento",
                columns: new[] { "EventoId", "PalestranteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPalestrante",
                table: "TbPalestrante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbLote",
                table: "TbLote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbEvento",
                table: "TbEvento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbLote_TbEvento_EventoId",
                table: "TbLote",
                column: "EventoId",
                principalTable: "TbEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPalestraneEvento_TbEvento_EventoId",
                table: "TbPalestraneEvento",
                column: "EventoId",
                principalTable: "TbEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPalestraneEvento_TbPalestrante_PalestranteId",
                table: "TbPalestraneEvento",
                column: "PalestranteId",
                principalTable: "TbPalestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbRedeSocial_TbEvento_EventoId",
                table: "TbRedeSocial",
                column: "EventoId",
                principalTable: "TbEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbRedeSocial_TbPalestrante_PalestranteId",
                table: "TbRedeSocial",
                column: "PalestranteId",
                principalTable: "TbPalestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbLote_TbEvento_EventoId",
                table: "TbLote");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPalestraneEvento_TbEvento_EventoId",
                table: "TbPalestraneEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPalestraneEvento_TbPalestrante_PalestranteId",
                table: "TbPalestraneEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_TbRedeSocial_TbEvento_EventoId",
                table: "TbRedeSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_TbRedeSocial_TbPalestrante_PalestranteId",
                table: "TbRedeSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbRedeSocial",
                table: "TbRedeSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPalestrante",
                table: "TbPalestrante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPalestraneEvento",
                table: "TbPalestraneEvento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbLote",
                table: "TbLote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbEvento",
                table: "TbEvento");

            migrationBuilder.RenameTable(
                name: "TbRedeSocial",
                newName: "RedesSocias");

            migrationBuilder.RenameTable(
                name: "TbPalestrante",
                newName: "Palestrante");

            migrationBuilder.RenameTable(
                name: "TbPalestraneEvento",
                newName: "PalestrantesEventos");

            migrationBuilder.RenameTable(
                name: "TbLote",
                newName: "Lotes");

            migrationBuilder.RenameTable(
                name: "TbEvento",
                newName: "Eventos");

            migrationBuilder.RenameIndex(
                name: "IX_TbRedeSocial_PalestranteId",
                table: "RedesSocias",
                newName: "IX_RedesSocias_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_TbRedeSocial_EventoId",
                table: "RedesSocias",
                newName: "IX_RedesSocias_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_TbPalestraneEvento_PalestranteId",
                table: "PalestrantesEventos",
                newName: "IX_PalestrantesEventos_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_TbLote_EventoId",
                table: "Lotes",
                newName: "IX_Lotes_EventoId");

            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "Eventos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEvento",
                table: "Eventos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedesSocias",
                table: "RedesSocias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palestrante",
                table: "Palestrante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PalestrantesEventos",
                table: "PalestrantesEventos",
                columns: new[] { "EventoId", "PalestranteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lotes",
                table: "Lotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Eventos_EventoId",
                table: "Lotes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PalestrantesEventos_Eventos_EventoId",
                table: "PalestrantesEventos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PalestrantesEventos_Palestrante_PalestranteId",
                table: "PalestrantesEventos",
                column: "PalestranteId",
                principalTable: "Palestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
