using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBebida.Migrations
{
    public partial class NovoSistemaBebida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaBebida_Bebidas_BebidaId",
                table: "VendaBebida");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaBebida_Vendas_VendaId",
                table: "VendaBebida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendaBebida",
                table: "VendaBebida");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vendas");

            migrationBuilder.RenameTable(
                name: "VendaBebida",
                newName: "VendasBebidas");

            migrationBuilder.RenameIndex(
                name: "IX_VendaBebida_VendaId",
                table: "VendasBebidas",
                newName: "IX_VendasBebidas_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_VendaBebida_BebidaId",
                table: "VendasBebidas",
                newName: "IX_VendasBebidas_BebidaId");

            migrationBuilder.AddColumn<bool>(
                name: "StatusPagamento",
                table: "Vendas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StatusPedido",
                table: "Vendas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendasBebidas",
                table: "VendasBebidas",
                column: "VendaBebidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendasBebidas_Bebidas_BebidaId",
                table: "VendasBebidas",
                column: "BebidaId",
                principalTable: "Bebidas",
                principalColumn: "BebidaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendasBebidas_Vendas_VendaId",
                table: "VendasBebidas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "VendaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendasBebidas_Bebidas_BebidaId",
                table: "VendasBebidas");

            migrationBuilder.DropForeignKey(
                name: "FK_VendasBebidas_Vendas_VendaId",
                table: "VendasBebidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendasBebidas",
                table: "VendasBebidas");

            migrationBuilder.DropColumn(
                name: "StatusPagamento",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "StatusPedido",
                table: "Vendas");

            migrationBuilder.RenameTable(
                name: "VendasBebidas",
                newName: "VendaBebida");

            migrationBuilder.RenameIndex(
                name: "IX_VendasBebidas_VendaId",
                table: "VendaBebida",
                newName: "IX_VendaBebida_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_VendasBebidas_BebidaId",
                table: "VendaBebida",
                newName: "IX_VendaBebida_BebidaId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendaBebida",
                table: "VendaBebida",
                column: "VendaBebidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaBebida_Bebidas_BebidaId",
                table: "VendaBebida",
                column: "BebidaId",
                principalTable: "Bebidas",
                principalColumn: "BebidaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaBebida_Vendas_VendaId",
                table: "VendaBebida",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "VendaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
