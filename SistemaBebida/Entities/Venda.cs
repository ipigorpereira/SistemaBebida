using SistemaBebida.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Entities
{
    public class Venda
    {
        public Guid VendaId { get; set; }

        public Guid ClienteId { get; set; }

        public DateTime Data { get; set; }

        public float Desconto { get; set; }

        public bool StatusPedido { get; set; }

        public bool StatusPagamento { get; set; }

        public Cliente Cliente { get; set; }

        public virtual ICollection<VendaBebida> VendasBebida { get; set; }
    }
}
