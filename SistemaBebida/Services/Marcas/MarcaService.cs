using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaBebida.Entities;
using SistemaBebida.Repositories.Estoques;
using SistemaBebida.Repositories.Marcas;
using SistemaBebida.Validations;

namespace SistemaBebida.Services.Marcas
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Marca> Create(Marca marca)
        {
            marca.MarcaId = Guid.NewGuid();
            await marca.Validar<MarcaValidator, Marca>();
            await _marcaRepository.Create(marca);
            return marca;
        }

        public Task Delete(Guid marcaId)
        {
            return _marcaRepository.Delete(marcaId);
        }

        public async Task<List<Marca>> List()
        {
            var marcas = await _marcaRepository.List();
            return marcas;
        }

        public  Task Update(Marca marca)
        {
           return _marcaRepository.Update(marca);
        }
    }
}
