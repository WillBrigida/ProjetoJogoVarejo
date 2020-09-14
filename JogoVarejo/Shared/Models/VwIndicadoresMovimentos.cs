using System;
using System.Collections.Generic;

namespace JogoVarejo.Shared.Models
{
    public partial class VwIndicadoresMovimentos
    {
        public int GrupoId { get; set; }
        public int? Duracao { get; set; }
        public int? DemandaTotal { get; set; }
        public decimal? DemandaMedia { get; set; }
        public decimal? Trmedio { get; set; }
        public int? ClientesAtendidos { get; set; }
        public decimal? EstoqueMedio { get; set; }
        public int? EstoqueMaximo { get; set; }
    }
}
