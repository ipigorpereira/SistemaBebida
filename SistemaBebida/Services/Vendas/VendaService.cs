using SistemaBebida.Entities;
using SistemaBebida.Repositories.Estoques;
using SistemaBebida.Repositories.Vendas;
using SistemaBebida.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IEstoqueRepository _estoqueRepository;

        public VendaService(IVendaRepository vendaRepository, IEstoqueRepository estoqueRepository)
        {
            _vendaRepository = vendaRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task AdicionaBebida(VendaBebida vendaBebida)
        {
            vendaBebida.VendaBebidaId = Guid.NewGuid();
            await vendaBebida.Validar<VendaBebidaValidator, VendaBebida>();
            await _vendaRepository.AdicionaBebida(vendaBebida);
            return;
        }

        public async Task<Venda> Create(Venda venda)
        {
            venda.VendaId = Guid.NewGuid();
            venda.StatusPagamento = false;
            venda.StatusPedido = false;
            await venda.Validar<VendaValidator, Venda>();
            await _vendaRepository.Create(venda);
            return venda;
        }

        public Task Delete(Guid vendaId)
        {
            return _vendaRepository.Delete(vendaId);
        }

        public async Task<List<Venda>> List(Guid clienteId)
        {
            var vendas = await _vendaRepository.List(clienteId);
            return vendas;
        }

        public async Task RemoveBebida(VendaBebida vendaBebida)
        {
            await vendaBebida.Validar<VendaBebidaValidator, VendaBebida>();
            await _vendaRepository.RemoveBebida(vendaBebida);
            return;
        }

        public async Task<float> SomaFinal(Guid vendaId)
        {
            return await _vendaRepository.SomaFinal(vendaId);
        }

        public async Task Update(Venda venda)
        {
            await _vendaRepository.Update(venda);
        }

        public async Task FinalizaVenda(Guid vendaId)
        {
            var vendaSelecionada = await _vendaRepository.GetVenda(vendaId);
            var vendaBebidas = 0;

            var bebidasGroup = vendaSelecionada.VendasBebida.GroupBy(c => c.BebidaId);
            foreach (var b in bebidasGroup)
            {
                var bebida = b.FirstOrDefault();
                var qtd = _estoqueRepository.QtdEstoque(bebida.BebidaId);

                if (qtd < b.Count())
                {
                    throw new System.ArgumentException("não há quantidade no estoque");
                }

                await _estoqueRepository.Remove(bebida.BebidaId, b.Count());
            }

            vendaSelecionada.StatusPedido = true;
            await _vendaRepository.Update(vendaSelecionada);
        }
    }
}