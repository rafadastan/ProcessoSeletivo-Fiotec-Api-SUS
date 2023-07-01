using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.SUS.Data.Migrations
{
    public partial class removendoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relatorio_Solicitante_SolicitanteId",
                table: "Relatorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitante",
                table: "Solicitante");

            migrationBuilder.DropIndex(
                name: "IX_Solicitante_Id",
                table: "Solicitante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio");

            migrationBuilder.DropIndex(
                name: "IX_Relatorio_Id",
                table: "Relatorio");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Solicitante");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Relatorio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitante",
                table: "Solicitante",
                column: "SolicitanteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio",
                column: "RelatorioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorio_Solicitante_SolicitanteId",
                table: "Relatorio",
                column: "SolicitanteId",
                principalTable: "Solicitante",
                principalColumn: "SolicitanteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relatorio_Solicitante_SolicitanteId",
                table: "Relatorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitante",
                table: "Solicitante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Solicitante",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Relatorio",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitante",
                table: "Solicitante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitante_Id",
                table: "Solicitante",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_Id",
                table: "Relatorio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorio_Solicitante_SolicitanteId",
                table: "Relatorio",
                column: "SolicitanteId",
                principalTable: "Solicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
