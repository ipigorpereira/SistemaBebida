using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.DTO_s.Vendas
{
    public class VendaRequest
    {
        public Guid ClienteId { get; set; }

        public DateTime Data { get; set; }

        public float Desconto { get; set; }

        public bool StatusPedido { get; set; }

        public bool StatusPagamento { get; set; }
    }
}
