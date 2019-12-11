using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Entities
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string  Endereco { get; set; }
    }
}
