using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.Marcas
{
    public interface IMarcaRepository
    {
        Task Create(Marca marca);

        Task<List<Marca>> List();

        Task Delete(Guid marcaId);

        Task Update(Marca marca);
    }
}
