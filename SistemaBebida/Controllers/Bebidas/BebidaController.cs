﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBebida.DTO_s.Bebidas;
using SistemaBebida.Entities;
using SistemaBebida.Services.Bebidas;

namespace SistemaBebida.Controllers.Bebidas
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : Controller
    {
        private readonly IBebidaService _bebidaService;
        private readonly IMapper _mapper;

        public BebidaController(IBebidaService bebidaService, IMapper mapper)
        {
            _bebidaService = bebidaService;
            _mapper = mapper;
        }

        //CREATE
        [HttpPost("create")]
        public async Task<BebidaResponse> Create([FromBody] BebidaRequest bebidaRequest)
        {
            var bebida = _mapper.Map<Bebida>(bebidaRequest);
            var p = await _bebidaService.Create(bebida);
            var response = _mapper.Map<BebidaResponse>(p);
            return response;
        }

        //UPDATE
        [HttpPost("update")]
        public async Task Update([FromBody] BebidaRequest bebidaRequest)
        {
            var bebida = _mapper.Map<Bebida>(bebidaRequest);
            await _bebidaService.Update(bebida);
        }

        //DELETE
        [HttpDelete("delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _bebidaService.Delete(id);
            return;
        }

        //LIST
        [HttpGet("list")]
        public async Task<IEnumerable<BebidaResponse>> List(Guid bebidaId, Guid marcaId, Guid tipoBebidaId, string descricao)
        {
            var list = await _bebidaService.List(bebidaId, marcaId, tipoBebidaId, descricao);

            var x = list.Select(p => _mapper.Map<BebidaResponse>(p)).ToList();
            return x;
        }
    }
}