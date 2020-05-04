using SistemaBebida.DTO_s.Bebidas;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Services.Bebidas
{
    public interface IBebidaService
    {
        Task<Bebida> Create(Bebida bebida);

        Task<List<Bebida>> List(Guid bebidaId, Guid marcaId, Guid tipoBebidaId, string descricao);

        Task Update(Bebida bebida);

        Task Delete(Guid bebidaId);

        Task<List<Bebida>> ListBebidaCompleta(Guid bebidaId);
    }
}
