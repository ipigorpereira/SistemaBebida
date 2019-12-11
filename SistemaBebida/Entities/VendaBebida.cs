using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Entities
{
    public class VendaBebida
    {
        public Guid VendaBebidaId { get; set; }
        public Guid BebidaId { get; set; }

        public Guid VendaId { get; set; }

        public Bebida Bebida { get; set; }

        public Venda Venda { get; set; }
    }
}
