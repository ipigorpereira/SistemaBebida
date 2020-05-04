using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Services.Marcas
{
    public interface IMarcaService
    {
        Task<Marca> Create(Marca marca);

        Task<List<Marca>> List(Guid id);

        Task Delete(Guid marcaId);

        Task Update(Marca marca);
    }
}
