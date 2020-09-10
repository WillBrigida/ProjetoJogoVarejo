using System;
using System.Collections.Generic;

namespace JogoVarejo.Shared.Models
{
    public partial class Controle
    {
        public int ControleId { get; set; }
        public int Fase { get; set; }
        public int Duracao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal CustoFixoDiario { get; set; }
        public decimal CustoUnitarioFrete { get; set; }
        public decimal CustoUnitarioEstocar { get; set; }
        public decimal GanhoUnitario { get; set; }
        public decimal DemandaMediaDiária { get; set; }
        public int DiasNoAno { get; set; }
    }
}
