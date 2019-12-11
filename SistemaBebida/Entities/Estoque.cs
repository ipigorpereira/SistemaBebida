using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Entities
{
    public class Estoque
    {
        public Guid EstoqueId { get; set; }

        public Guid BebidaId { get; set; }

        public int Quantidade { get; set; }

        public Bebida Bebida { get; set; }
    }
}
