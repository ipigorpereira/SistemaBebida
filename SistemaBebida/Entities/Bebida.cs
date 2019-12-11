using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Entities
{
    public class Bebida
    {
        public Guid BebidaId { get; set; }

        public Guid MarcaId { get; set; }

        public Guid TipoBebidaId { get; set; }

        public string Descricao { get; set; }

        public float Valor { get; set; }

        public Marca Marca { get; set; }

        public TipoBebida TipoBebida { get; set; }

        public virtual ICollection<VendaBebida> VendasBebida { get; set; }
    }
}
