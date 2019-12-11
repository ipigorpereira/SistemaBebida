using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaBebida.Entities;

namespace SistemaBebida.Repositories.Estoques
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ProgramContext _context;

        public EstoqueRepository(ProgramContext context)
        {
            _context = context;
        }

        public Task Adiciona(Guid produtoId, int qtd)
        {
            var estoque = _context.Estoques.Where(c => c.BebidaId == produtoId).First();
            estoque.Quantidade = estoque.Quantidade + qtd;
            return _context.SaveChangesAsync();

        }

        public Task Create(Estoque estoque)
        {
            _context.Estoques.Add(estoque);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid bebidaId)
        {
            var estoque = _context.Estoques.Where(c => c.BebidaId == bebidaId).First();
            _context.Estoques.Remove(estoque);
            return _context.SaveChangesAsync();
        }

        public Task<List<Estoque>> List(Guid bebidaId)
        {
            var estoques = _context.Estoques.AsQueryable();
            if (bebidaId != Guid.Empty && bebidaId != default)
                estoques = estoques.Where(x => x.BebidaId == bebidaId);
            return estoques.AsNoTracking().ToListAsync();
        }

        public int QtdEstoque(Guid bebidaId)
        {
            var estoques = _context.Estoques.AsQueryable();
            var qtd = 0;
            if (bebidaId != Guid.Empty && bebidaId != default)
            {
                qtd = estoques.Where(x => x.BebidaId == bebidaId).Select(y=>y.Quantidade).FirstOrDefault();
            }

            return qtd;
            
        }

        public Task Remove(Guid produtoId, int qtd)
        {
            var estoque = _context.Estoques.Where(c => c.BebidaId == produtoId).First();
            estoque.Quantidade = estoque.Quantidade - qtd;
            return _context.SaveChangesAsync();
        }
    }
}
