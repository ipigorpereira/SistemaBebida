using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.Vendas
{
    public interface IVendaRepository
    {
        Task Create(Venda venda);

        Task<List<Venda>> List(Guid clienteId);

        Task<float> SomaFinal(Guid vendaId);

        Task Delete(Guid vendaId);

        Task Update(Venda venda);

        Task AdicionaBebida(VendaBebida vendaBebida);

        Task RemoveBebida(VendaBebida vendaBebida);

        Task<Venda> GetVenda(Guid vendaId);
    }
}
