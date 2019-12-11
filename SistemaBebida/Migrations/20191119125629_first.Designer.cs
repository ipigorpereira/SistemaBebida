﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaBebida.Repositories;

namespace SistemaBebida.Migrations
{
    [DbContext(typeof(ProgramContext))]
    [Migration("20191119125629_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaBebida.Entities.Bebida", b =>
                {
                    b.Property<Guid>("BebidaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<Guid>("MarcaId");

                    b.Property<Guid>("TipoBebidaId");

                    b.Property<float>("Valor");

                    b.HasKey("BebidaId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("TipoBebidaId");

                    b.ToTable("Bebidas");
                });

            modelBuilder.Entity("SistemaBebida.Entities.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaBebida.Entities.Estoque", b =>
                {
                    b.Property<Guid>("EstoqueId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BebidaId");

                    b.Property<int>("Quantidade");

                    b.HasKey("EstoqueId");

                    b.HasIndex("BebidaId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("SistemaBebida.Entities.Marca", b =>
                {
                    b.Property<Guid>("MarcaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("MarcaId");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("SistemaBebida.Entities.TipoBebida", b =>
                {
                    b.Property<Guid>("TipoBebidaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.HasKey("TipoBebidaId");

                    b.ToTable("TiposBebidas");
                });

            modelBuilder.Entity("SistemaBebida.Entities.Venda", b =>
                {
                    b.Property<Guid>("VendaId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<DateTime>("Data");

                    b.Property<float>("Desconto");

                    b.Property<int>("Status");

                    b.HasKey("VendaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("SistemaBebida.Entities.VendaBebida", b =>
                {
                    b.Property<Guid>("VendaBebidaId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BebidaId");

                    b.Property<Guid>("VendaId");

                    b.HasKey("VendaBebidaId");

                    b.HasIndex("BebidaId");

                    b.HasIndex("VendaId");

                    b.ToTable("VendaBebida");
                });

            modelBuilder.Entity("SistemaBebida.Entities.Bebida", b =>
                {
                    b.HasOne("SistemaBebida.Entities.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaBebida.Entities.TipoBebida", "TipoBebida")
                        .WithMany()
                        .HasForeignKey("TipoBebidaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaBebida.Entities.Estoque", b =>
                {
                    b.HasOne("SistemaBebida.Entities.Bebida", "Bebida")
                        .WithMany()
                        .HasForeignKey("BebidaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaBebida.Entities.Venda", b =>
                {
                    b.HasOne("SistemaBebida.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaBebida.Entities.VendaBebida", b =>
                {
                    b.HasOne("SistemaBebida.Entities.Bebida", "Bebida")
                        .WithMany("VendasBebida")
                        .HasForeignKey("BebidaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaBebida.Entities.Venda", "Venda")
                        .WithMany("VendasBebida")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
