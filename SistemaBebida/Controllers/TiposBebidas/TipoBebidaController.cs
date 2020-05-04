using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBebida.DTO_s.TiposBebidas;
using SistemaBebida.Entities;
using SistemaBebida.Services.TiposBebidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Controllers.TiposBebidas
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoBebidaController : Controller
    {
        private readonly ITipoBebidaService _tipoBebidaService;
        private readonly IMapper _mapper;

        public TipoBebidaController(ITipoBebidaService tipoBebidaService, IMapper mapper)
        {
            _tipoBebidaService = tipoBebidaService;
            _mapper = mapper;
        }

        //CREATE
        [HttpPost("create")]
        public async Task<TipoBebidaResponse> Create([FromBody] TipoBebidaRequest tipoBebidaRequest)
        {
            var p = await _tipoBebidaService.Create(tipoBebidaRequest as TipoBebida);
            var response = _mapper.Map<TipoBebidaResponse>(p);
            return response;
        }

        //UPDATE
        [HttpPost("update")]
        public async Task Update([FromBody] TipoBebidaRequest tipoBebidaRequest)
        {
            await _tipoBebidaService.Update(tipoBebidaRequest as TipoBebida);
        }

        //DELETE
        [HttpDelete("delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _tipoBebidaService.Delete(id);
            return;
        }

        //LIST
        [HttpGet("list")]
        public async Task<IEnumerable<TipoBebidaResponse>> List(Guid id)
        {
            var list = await _tipoBebidaService.List(id);

            var x = list.Select(p => _mapper.Map<TipoBebidaResponse>(p)).ToList();
            return x;
        }
        //LIST
        [HttpGet("listone/{id}")]
        public async Task<TipoBebidaResponse> ListOne(Guid id)
        {
            var list = await _tipoBebidaService.List(id);

            var x = list.Select(p => _mapper.Map<TipoBebidaResponse>(p)).First();
            return x;
        }
    }
}