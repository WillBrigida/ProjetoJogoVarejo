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
        public T Item { get; set; }
        public List<T> Items { get; set; }

    }
}
