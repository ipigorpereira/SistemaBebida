using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.DTO_s.Bebidas
{
    public class BebidaResponse
    {
        public Guid BebidaId { get; set; }

        public Guid MarcaId { get; set; }

        public Guid TipoBebidaId { get; set; }

        public string Descricao { get; set; }

        public float Valor { get; set; }
    }
}
