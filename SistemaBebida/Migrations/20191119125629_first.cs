using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBebida.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposBebidas",
                columns: table => new
                {
                    TipoBebidaId = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposBebidas", x => x.TipoBebidaId);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaId = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Desconto = table.Column<float>(nullable: true),
                    Status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    BebidaId = table.Column<Guid>(nullable: false),
                    MarcaId = table.Column<Guid>(nullable: false),
                    TipoBebidaId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.BebidaId);
                    table.ForeignKey(
                        name: "FK_Bebidas_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bebidas_TiposBebidas_TipoBebidaId",
                        column: x => x.TipoBebidaId,
                        principalTable: "TiposBebidas",
                        principalColumn: "TipoBebidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<Guid>(nullable: false),
                    BebidaId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.EstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoques_Bebidas_BebidaId",
                        column: x => x.BebidaId,
                        principalTable: "Bebidas",
                        principalColumn: "BebidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaBebida",
                columns: table => new
                {
                    VendaBebidaId = table.Column<Guid>(nullable: false),
                    BebidaId = table.Column<Guid>(nullable: false),
                    VendaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaBebida", x => x.VendaBebidaId);
                    table.ForeignKey(
                        name: "FK_VendaBebida_Bebidas_BebidaId",
                        column: x => x.BebidaId,
                        principalTable: "Bebidas",
                        principalColumn: "BebidaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaBebida_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bebidas_MarcaId",
                table: "Bebidas",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bebidas_TipoBebidaId",
                table: "Bebidas",
                column: "TipoBebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_BebidaId",
                table: "Estoques",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaBebida_BebidaId",
                table: "VendaBebida",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaBebida_VendaId",
                table: "VendaBebida",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "VendaBebida");

            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "TiposBebidas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
