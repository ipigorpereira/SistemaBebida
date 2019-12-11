using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBebida.DTO_s.Estoques;
using SistemaBebida.Entities;
using SistemaBebida.Services.Estoques;

namespace SistemaBebida.Controllers.Estoques
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        public EstoqueController(IEstoqueService estoqueService, IMapper mapper)
        {
            _estoqueService = estoqueService;
            _mapper = mapper;
        }

        //CREATE
        [HttpPost("create")]
        public async Task<EstoqueResponse> Create([FromBody] EstoqueRequest estoqueRequest)
        {
            var estoque = _mapper.Map<Estoque>(estoqueRequest);
            var p = await _estoqueService.Create(estoque);
            var response = _mapper.Map<EstoqueResponse>(p);
            return response;
        }


        //DELETE
        [HttpDelete("delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _estoqueService.Delete(id);
            return;
        }

        //LIST
        [HttpGet("list")]
        public async Task<IEnumerable<EstoqueResponse>> List(Guid bebidaId)
        {
            var list = await _estoqueService.List(bebidaId);

            var x = list.Select(p => _mapper.Map<EstoqueResponse>(p)).ToList();
            return x;
        }

        //ADICIONA
        [HttpPost("adiciona")]
        public async Task Adiciona([FromBody] EstoqueAddRemove estoqueRequest)
        {
            var bebidaId = estoqueRequest.BebidaId;
            var qtd = estoqueRequest.Qtd;
            await _estoqueService.Adiciona(bebidaId, qtd);
            
        }

        //ADICIONA
        [HttpPost("remove")]
        public async Task Remove([FromBody] EstoqueAddRemove estoqueRequest)
        {
            var bebidaId = estoqueRequest.BebidaId;
            var qtd = estoqueRequest.Qtd;
            await _estoqueService.Remove(bebidaId, qtd);

        }

    }
}