using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Services.Estoques
{
    public interface IEstoqueService
    {
        Task<Estoque> Create(Estoque estoque);

        Task<List<Estoque>> List(Guid bebidaId);

        Task Delete(Guid bebidaId);
        
        Task Adiciona(Guid produtoId, int qtd);

        Task Remove(Guid produtoId, int qtd);
    }
}
