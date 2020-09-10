using System;
using System.Collections.Generic;

#nullable disable

namespace JogoVarejo_Server.Shared.Models
{
    public partial class Grupo
    {
        public int GrupoId { get; set; }
        public string Quando { get; set; }
        public string Quanto { get; set; }
        public int? GrupoOperador { get; set; }
    }
}
