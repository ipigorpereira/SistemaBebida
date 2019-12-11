using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBebida.DTO_s.Vendas;
using SistemaBebida.DTO_s.VendasBebidas;
using SistemaBebida.Entities;
using SistemaBebida.Services.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Controllers.Vendas
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;

        public VendaController(IVendaService vendaService, IMapper mapper)
        {
            _vendaService = vendaService;
            _mapper = mapper;
        }

        //CREATE
        [HttpPost("create")]
        public async Task<VendaResponse> Create([FromBody] VendaRequest vendaRequest)
        {
            var venda = _mapper.Map<Venda>(vendaRequest);
            var p = await _vendaService.Create(venda);
            var response = _mapper.Map<VendaResponse>(p);
            return response;
        }

        //UPDATE
        [HttpPost("update")]
        public async Task Update([FromBody] VendaRequest vendaRequest)
        {
            var venda = _mapper.Map<Venda>(vendaRequest);
            await _vendaService.Update(venda);
        }

        //DELETE
        [HttpDelete("delete/{id}")]
        public async Task Delete(Guid vendaId)
        {
            return; await _vendaService.Delete(vendaId);
        }

        //LIST
        [HttpGet("list")]
        public async Task<IEnumerable<VendaResponse>> List(Guid clienteId)
        {
            var list = await _vendaService.List(clienteId);

            var x = list.Select(p => _mapper.Map<VendaResponse>(p)).ToList();
            return x;
        }

        //ADICIONA VENDABEBIDA
        [HttpPost("addbebida")]
        public async Task AdicionaBebida([FromBody] VendaBebidaRequest vendaBebidaRequest)
        {
            var vendaBebida = _mapper.Map<VendaBebida>(vendaBebidaRequest);
            for (int x = 0;  x < vendaBebidaRequest.Quantidade; x++)
            {
               await _vendaService.AdicionaBebida(vendaBebida);
            }

            return;
        }

        //REMOVE VENDABEBIDA
        [HttpPost("removebebida")]
        public Task RemoveBebida([FromBody] VendaBebidaRequest vendaBebidaRequest)
        {
            var vendaBebida = _mapper.Map<VendaBebida>(vendaBebidaRequest);
            return _vendaService.RemoveBebida(vendaBebida);
        }

        //BUSCA SOMA VENDA
        [HttpPost("soma")]
        public async Task<float> Soma(Guid vendaId)
        {
            var x = await _vendaService.SomaFinal(vendaId);
            return x;
        }

        //FINALIZAVENDA
        [HttpPost("finaliza")]
        public async Task FinalizaVenda(Guid vendaId)
        {
            
            await _vendaService.FinalizaVenda(vendaId);
        }
    }
}