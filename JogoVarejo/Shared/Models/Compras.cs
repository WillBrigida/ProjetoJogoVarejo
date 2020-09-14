using System;
using System.Collections.Generic;

namespace JogoVarejo.Shared.Models
{
    public partial class Compras
    {
        public int CompraId { get; set; }
        public int GrupoId { get; set; }
        public int DiaCompra { get; set; }
        public int DiaEntrega { get; set; }
        public int QuantCompra { get; set; }
        public int? OcorreuFalta { get; set; }
    }
}
