using System;
using System.Collections.Generic;

namespace JogoVarejo.Shared.Models
{
    public partial class Grupos
    {
        public int GrupoId { get; set; }
        public string Quando { get; set; }
        public string Quanto { get; set; }
        public int? GrupoOperador { get; set; }
    }
}
