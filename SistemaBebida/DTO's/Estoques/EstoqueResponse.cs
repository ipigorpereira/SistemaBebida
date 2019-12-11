using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.DTO_s.Estoques
{
    public class EstoqueResponse
    {
        public Guid EstoqueId { get; set; }

        public Guid BebidaId { get; set; }

        public int Quantidade { get; set; }

        public Bebida Bebida { get; set; }
    }
}
