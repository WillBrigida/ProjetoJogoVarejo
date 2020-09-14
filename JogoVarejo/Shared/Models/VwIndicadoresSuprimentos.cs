using System;
using System.Collections.Generic;

namespace JogoVarejo.Shared.Models
{
    public partial class VwIndicadoresSuprimentos
    {
        public int GrupoId { get; set; }
        public int? NumeroEncomendas { get; set; }
        public decimal? CustoFrete { get; set; }
        public int? QuebrasDeEstoque { get; set; }
        public decimal? NivelServiçoSuprimentos { get; set; }
    }
}
