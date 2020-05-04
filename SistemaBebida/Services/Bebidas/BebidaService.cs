using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaBebida.DTO_s.Bebidas;
using SistemaBebida.Entities;
using SistemaBebida.Repositories.Bebidas;
using SistemaBebida.Validations;

namespace SistemaBebida.Services.Bebidas
{
    public class BebidaService : IBebidaService
    {
        private readonly IBebidaRepository _bebidaRepository;

        public BebidaService(IBebidaRepository bebidaRepository)
        {
            _bebidaRepository = bebidaRepository;
        }

        public async Task<Bebida> Create(Bebida bebida)
        {
            bebida.BebidaId = Guid.NewGuid();
            await bebida.Validar<BebidaValidator, Bebida>();
            await _bebidaRepository.Create(bebida);
            return bebida;
        }

        public Task Delete(Guid bebidaId)
        {
            return _bebidaRepository.Delete(bebidaId);
        }

        public async Task<List<Bebida>> List(Guid bebidaId, Guid marcaId, Guid tipoBebidaId, string descricao)
        {
            var bebidas = await _bebidaRepository.List(bebidaId, marcaId, tipoBebidaId, descricao);
            return bebidas;
        }

        public async Task<List<Bebida>> ListBebidaCompleta(Guid bebidaId)
        {
            var bebidas = await _bebidaRepository.ListBebidaCompleta(bebidaId);
            return bebidas;
        }

        public Task Update(Bebida bebida)
        {
            return _bebidaRepository.Update(bebida);
        }
    }
}
