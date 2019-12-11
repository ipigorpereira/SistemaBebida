using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBebida.DTO_s.Clientes;
using SistemaBebida.Entities;
using SistemaBebida.Services.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Controllers.Clientes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        //CREATE
        [HttpPost("create")]
        public async Task<ClienteResponse> Create([FromBody] ClienteRequest clienteRequest)
        {
            var p = await _clienteService.Create(clienteRequest as Cliente);
            var response = _mapper.Map<ClienteResponse>(p);
            return response;
        }

        //UPDATE
        [HttpPost("update")]
        public async Task<ClienteResponse> Update([FromBody] ClienteRequest clienteRequest)
        {
            var p = await _clienteService.Update(clienteRequest as Cliente);
            var response = _mapper.Map<ClienteResponse>(p);
            return response;
        }

        //DELETE
        [HttpDelete("delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _clienteService.Delete(id);
            return;
        }

        //LIST
        [HttpGet("list")]
        public async Task<IEnumerable<ClienteResponse>> List(Guid id)
        {
            var list = await _clienteService.List(id);

            var x = list.Select(p => _mapper.Map<ClienteResponse>(p)).ToList();
            return x;
        }
    }
}
