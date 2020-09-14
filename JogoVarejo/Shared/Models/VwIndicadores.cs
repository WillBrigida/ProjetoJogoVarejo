using System;
using System.Collections.Generic;

namespace JogoVarejo.Shared.Models
{
    public partial class VwIndicadores
    {
        public int GrupoId { get; set; }
        public int? Duracao { get; set; }
        public int? DemandaTotal { get; set; }
        public decimal? DemandaMedia { get; set; }
        public decimal? Trmedio { get; set; }
        public int? ClientesAtendidos { get; set; }
        public decimal? Ganho { get; set; }
        public int? ClientesPerdidos { get; set; }
        public decimal? GanhoPerdido { get; set; }
        public decimal? NivelServicoCliente { get; set; }
        public decimal? EstoqueMedio { get; set; }
        public decimal? CoberturaEstoqueMedio { get; set; }
        public decimal? CapitalEstoqueMedio { get; set; }
        public decimal? CustoEstocar { get; set; }
        public decimal? Giro { get; set; }
        public int? EstoqueMaximo { get; set; }
        public decimal? CoberturaEstoqueMaximo { get; set; }
        public decimal? CapitalEstoqueMaximo { get; set; }
        public int? NumeroEncomendas { get; set; }
        public decimal? CustoFrete { get; set; }
        public int? QuebrasDeEstoque { get; set; }
        public decimal? NivelServiçoSuprimentos { get; set; }
        public decimal? GanhoPotencial { get; set; }
        public decimal? CustoGerenciado { get; set; }
        public decimal? CustoFixo { get; set; }
        public decimal? Lucro { get; set; }
        public decimal? Lucratividade { get; set; }
    }
}
