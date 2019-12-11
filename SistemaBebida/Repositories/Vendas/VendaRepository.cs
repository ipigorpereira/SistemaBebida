using Microsoft.EntityFrameworkCore;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.Vendas
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ProgramContext _context;

        public VendaRepository(ProgramContext context)
        {
            _context = context;
        }

        public Task AdicionaBebida(VendaBebida vendaBebida)
        {
            _context.VendasBebidas.Add(vendaBebida);
            return _context.SaveChangesAsync();
        }

        public Task Create(Venda venda)
        {
            _context.Vendas.Add(venda);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid vendaId)
        {
            var venda = _context.Vendas.Where(c => c.VendaId == vendaId).First();
            _context.Vendas.Remove(venda);
            return _context.SaveChangesAsync();
        }

        public Task<List<Venda>> List(Guid clienteId)
        {
            var vendas = _context.Vendas.AsQueryable();

            if (clienteId != Guid.Empty && clienteId != default)
                vendas = vendas.Where(x => x.ClienteId == clienteId);

            return vendas.AsNoTracking().ToListAsync();
        }

        public Task<Venda> GetVenda(Guid vendaId)
        {
            var vendas = _context.Vendas.Where(x => x.VendaId == vendaId).Include(t=>t.VendasBebida).Where(c=>c.VendaId == vendaId).FirstOrDefaultAsync();

            return vendas;
        }

        public Task RemoveBebida(VendaBebida vendaBebida)
        {
            var vendaBebidaRemover = _context.VendasBebidas.Where(c => c.VendaId == vendaBebida.VendaId && c.BebidaId == vendaBebida.BebidaId).First();
            _context.VendasBebidas.Remove(vendaBebidaRemover);
            return _context.SaveChangesAsync();
        }

        public async Task<float> SomaFinal(Guid vendaId)
        {
            var vendas = _context.VendasBebidas.AsQueryable();
            var soma = vendas.Include(t => t.Bebida).Where(c => c.VendaId == vendaId).Select(p => p.Bebida.Valor).Sum();
            var desconto = _context.Vendas.Where(c => c.VendaId == vendaId).Select(x => x.Desconto).First();

            if (desconto != 0 && desconto != null && desconto < soma)
            {
                soma = soma - desconto;
            }

            return soma;
        }

        public Task Update(Venda venda)
        {
            _context.Vendas.Update(venda);
            return _context.SaveChangesAsync();
        }
    }
}