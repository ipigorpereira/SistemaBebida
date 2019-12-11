using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaBebida.DTO_s.Bebidas;
using SistemaBebida.Entities;

namespace SistemaBebida.Repositories.Bebidas
{
    public class BebidaRepository : IBebidaRepository
    {
        private readonly ProgramContext _context;

        public BebidaRepository(ProgramContext context)
        {
            _context = context;
        }
        public Task Create(Bebida bebida)
        {
            _context.Bebidas.Add(bebida);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid bebidaId)
        {
            var bebida = _context.Bebidas.Where(c => c.BebidaId == bebidaId).First();
            _context.Bebidas.Remove(bebida);
            return _context.SaveChangesAsync();
        }

        public Task<List<Bebida>> List(Guid bebidaId, Guid marcaId, Guid tipoBebidaId, string descricao)
        {
            var bebidas = _context.Bebidas.AsQueryable();

            if (bebidaId != Guid.Empty && bebidaId != default)
                bebidas = bebidas.Where(x => x.BebidaId == bebidaId);
            if (string.IsNullOrWhiteSpace(descricao) == false)
                bebidas = bebidas.Where(x => x.Descricao == descricao);
            if (marcaId != Guid.Empty && marcaId != default)
                bebidas = bebidas.Where(x => x.MarcaId == marcaId);
            if (tipoBebidaId != Guid.Empty && tipoBebidaId != default)
                bebidas = bebidas.Where(x => x.TipoBebidaId == tipoBebidaId);


            return bebidas.AsNoTracking().ToListAsync();
        }

        public Task Update(Bebida bebida)
        {
            _context.Update(bebida);
            return _context.SaveChangesAsync();
        }
    }
}