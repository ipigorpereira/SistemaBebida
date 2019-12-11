using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBebida.Services.Vendas
{
    public interface IVendaService
    {
        Task<Venda> Create(Venda venda);

        Task<List<Venda>> List(Guid clienteId);

        Task<float> SomaFinal(Guid vendaId);

        Task Delete(Guid vendaId);

        Task Update(Venda venda);

        Task AdicionaBebida(VendaBebida vendaBebida);

        Task RemoveBebida(VendaBebida vendaBebida);

        Task FinalizaVenda(Guid vendaId);
    }
}