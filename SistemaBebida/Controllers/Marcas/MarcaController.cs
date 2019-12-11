using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBebida.DTO_s.Marcas;
using SistemaBebida.Entities;
using SistemaBebida.Services.Marcas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Controllers.Marcas
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : Controller
    {
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }

        //CREATE
        [HttpPost("create")]
        public async Task<MarcaResponse> Create([FromBody] MarcaRequest marcaRequest)
        {
            var p = await _marcaService.Create(marcaRequest as Marca);
            var response = _mapper.Map<MarcaResponse>(p);
            return response;
        }

        //UPDATE
        [HttpPost("update")]
        public async Task Update([FromBody] MarcaRequest marcaRequest)
        {
            await _marcaService.Update(marcaRequest as Marca);
        }

        //DELETE
        [HttpDelete("delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _marcaService.Delete(id);
            return;
        }

        //LIST
        [HttpGet("list")]
        public async Task<IEnumerable<MarcaResponse>> List()
        {
            var list = await _marcaService.List();

            var x = list.Select(p => _mapper.Map<MarcaResponse>(p)).ToList();
            return x;
        }
    }
}