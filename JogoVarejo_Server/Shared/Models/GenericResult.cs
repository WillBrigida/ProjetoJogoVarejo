using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Shared.Models
{
    public class GenericResult<T>
    {
        public bool Sucesso { get; set; }
        public string Erro { get; set; }
        public T obj { get; set; }

    }
}
