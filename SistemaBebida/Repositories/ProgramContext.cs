using Microsoft.EntityFrameworkCore;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories
{
    public class ProgramContext : DbContext
    {

        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        {
        }

        public DbSet<Bebida> Bebidas { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<VendaBebida> VendasBebidas { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<TipoBebida> TiposBebidas { get; set; }

        public DbSet<Estoque> Estoques { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProgramContext).Assembly);
        }

    }

}

