using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.Estoques
{
    public interface IEstoqueRepository
    {
        Task Create(Estoque estoque);

        Task<List<Estoque>> List(Guid bebidaId);

        Task Delete(Guid bebidaId);

        Task Adiciona(Guid produtoId, int qtd);

        Task Remove(Guid produtoId, int qtd);

        int QtdEstoque(Guid bebidaId);
    }
}
