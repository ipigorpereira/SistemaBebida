using SistemaBebida.Entities;
using SistemaBebida.Repositories.TiposBebidas;
using SistemaBebida.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBebida.Services.TiposBebidas
{
    public class TipoBebidaService : ITipoBebidaService
    {
        private readonly ITipoBebidaRepository _tipoBebidaRepository;

        public TipoBebidaService(ITipoBebidaRepository tipoBebidaRepository)
        {
            _tipoBebidaRepository = tipoBebidaRepository;
        }

        public async Task<TipoBebida> Create(TipoBebida tipoBebida)
        {
            tipoBebida.TipoBebidaId = Guid.NewGuid();
            await tipoBebida.Validar<TipoBebidaValidator, TipoBebida>();
            await _tipoBebidaRepository.Create(tipoBebida);
            return tipoBebida;
        }

        public Task Delete(Guid tipoBebidaId)
        {
            return _tipoBebidaRepository.Delete(tipoBebidaId);
        }

        public async Task<List<TipoBebida>> List(Guid id)
        {
            var tiposBebidas = await _tipoBebidaRepository.List(id);
            return tiposBebidas;

        }

        public Task Update(TipoBebida tipoBebida)
        {
            return _tipoBebidaRepository.Update(tipoBebida);
        }
    }
}