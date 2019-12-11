using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.DTO_s.Estoques
{
    public class EstoqueAddRemove
    {
        public Guid BebidaId { get; set; }

        public int Qtd { get; set; }
    }
}
