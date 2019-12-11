using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.DTO_s.VendasBebidas
{
    public class VendaBebidaRequest
    {
        public Guid VendaBebidaId { get; set; }
        public Guid BebidaId { get; set; }

        public Guid VendaId { get; set; }

        public int Quantidade { get; set; }
    }
}
