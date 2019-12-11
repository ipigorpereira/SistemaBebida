using SistemaBebida.Entities;
using System;

namespace SistemaBebida.DTO_s.Bebidas
{
    public class BebidaRequest
    {
        public Guid BebidaId { get; set; }
        public Guid MarcaId { get; set; }

        public Guid TipoBebidaId { get; set; }

        public string Descricao { get; set; }

        public float Valor { get; set; }

    }
}