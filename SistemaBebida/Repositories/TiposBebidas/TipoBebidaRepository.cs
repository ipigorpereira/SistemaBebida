using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaBebida.Entities;

namespace SistemaBebida.Repositories.TiposBebidas
{
    public class TipoBebidaRepository : ITipoBebidaRepository
    {
        private readonly ProgramContext _context;

        public TipoBebidaRepository(ProgramContext context)
        {
            _context = context;
        }
        public Task Create(TipoBebida tipoBebida)
        {
            _context.TiposBebidas.Add(tipoBebida);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid tipoBebidaId)
        {
            var tipoBebida = _context.TiposBebidas.Where(c => c.TipoBebidaId == tipoBebidaId).First();
            _context.TiposBebidas.Remove(tipoBebida);
            return _context.SaveChangesAsync();
        }

        public Task<List<TipoBebida>> List(Guid id)
        {

            var tiposBebidas = _context.TiposBebidas.AsQueryable();

            if (id != Guid.Empty && id != default)
                tiposBebidas = tiposBebidas.Where(x => x.TipoBebidaId == id);
            return tiposBebidas.AsNoTracking().ToListAsync();
        }

        public Task Update(TipoBebida tipoBebida)
        {
            _context.TiposBebidas.Update(tipoBebida);
            return _context.SaveChangesAsync();
        }
    }
}
