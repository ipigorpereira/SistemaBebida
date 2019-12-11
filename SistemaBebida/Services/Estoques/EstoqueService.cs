using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaBebida.Entities;
using SistemaBebida.Repositories.Estoques;
using SistemaBebida.Validations;

namespace SistemaBebida.Services.Estoques
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public Task Adiciona(Guid produtoId, int qtd)
        {
            return _estoqueRepository.Adiciona(produtoId, qtd);
        }

        public async Task<Estoque> Create(Estoque estoque)
        {
            estoque.EstoqueId = Guid.NewGuid();
            estoque.Quantidade = 0;
            await estoque.Validar<EstoqueValidator, Estoque>();
            await _estoqueRepository.Create(estoque);
            return estoque;
        }

        public Task Delete(Guid bebidaId)
        {
            return _estoqueRepository.Delete(bebidaId);
        }

        public async Task<List<Estoque>> List(Guid bebidaId)
        {
            var estoque = await _estoqueRepository.List(bebidaId);
            return estoque;
        }

        public Task Remove(Guid produtoId, int qtd)
        {
            return _estoqueRepository.Remove(produtoId, qtd);
        }
    }
}
