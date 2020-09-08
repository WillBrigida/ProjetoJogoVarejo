using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVarejo.Shared.Models.Utils
{
    public class GenericResult<T>
    {
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
        public T Item { get; set; }
        public List<T> Items { get; set; }
        public string Token { get; set; }
    }
}
