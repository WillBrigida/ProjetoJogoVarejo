using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Shared.Models
{
    public class GenericResult<T>
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object Item { get; set; }
        public IEnumerable<object> Items { get; set; }

    }
}
