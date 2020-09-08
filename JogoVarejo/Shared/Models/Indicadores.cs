using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVarejo.Shared.Models
{
    public class Indicadores
    {
        public int GrupoId { get; set; }
        public int ClientesAtendidos { get; set; }
        public decimal Ganho { get; set; }
        public int ClientesPerdidos { get; set; }
        public decimal GanhoPerdido { get; set; }
        public double NivelServiçoCliente { get; set; }
        public decimal EstoqueMed { get; set; }
        public decimal CobEstoqueMed { get; set; }
        public decimal CapitalEstoqueMed { get; set; }
        public decimal CustoEstocar { get; set; }
        public decimal Giro { get; set; }
        public decimal EstoqueMax { get; set; }
        public decimal CobEstoqueMax { get; set; }
        public decimal CapitalEstoqueMax { get; set; }
        public int NumEncomendas { get; set; }
        public decimal CustoFrete { get; set; }
        public int QuebrasEstoque { get; set; }
        public double NivelServiçoSupr { get; set; }
        public int GanhoPotencial { get; set; }
        public decimal CustoGerenciado { get; set; }
        public decimal CustoFixo { get; set; }
        public decimal Lucro { get; set; }
        public decimal Lucratividade { get; set; }
    }
}
