using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.TiposBebidas
{
    public interface ITipoBebidaRepository
    {
        Task Create(TipoBebida tipoBebida);

        Task<List<TipoBebida>> List();

        Task Delete(Guid tipoBebidaId);

        Task Update(TipoBebida tipoBebida);
    }
}
