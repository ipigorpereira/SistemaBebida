using SistemaBebida.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.DTO_s.Vendas
{
    public class VendaResponse
    {
        public Guid VendaId { get; set; }

        public Guid ClienteId { get; set; }

        public DateTime Data { get; set; }

        public float Desconto { get; set; }

        public bool StatusPagamento { get; set; }

        public bool StatusPedido { get; set; }
    }
}
