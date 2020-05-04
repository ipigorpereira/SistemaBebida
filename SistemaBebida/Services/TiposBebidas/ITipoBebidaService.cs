using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Services.TiposBebidas
{
    public interface ITipoBebidaService
    {
        Task<TipoBebida> Create(TipoBebida tipoBebida);

        Task<List<TipoBebida>> List(Guid id);

        Task Delete(Guid tipoBebidaId);

        Task Update(TipoBebida tipoBebida);
    }
}
