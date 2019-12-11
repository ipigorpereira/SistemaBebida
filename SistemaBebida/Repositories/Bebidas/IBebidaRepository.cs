using SistemaBebida.DTO_s.Bebidas;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.Bebidas
{
    public interface IBebidaRepository
    {
        Task Create(Bebida bebida);

        Task<List<Bebida>> List(Guid bebidaId, Guid marcaId, Guid tipoBebidaId, string descricao);

        Task Delete(Guid bebidaId);

        Task Update(Bebida bebida);
    }
}
