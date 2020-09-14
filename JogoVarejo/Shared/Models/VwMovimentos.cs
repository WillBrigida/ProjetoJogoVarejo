using System;
using System.Collections.Generic;

namespace JogoVarejo.Shared.Models
{
    public partial class VwMovimentos
    {
        public int MovimentoId { get; set; }
        public int GrupoId { get; set; }
        public int Dia { get; set; }
        public int Recebido { get; set; }
        public int Areceber { get; set; }
        public int SaldoInicial { get; set; }
        public int? Comprado { get; set; }
        public int? Prazo { get; set; }
        public int? Demanda { get; set; }
        public int? Vendido { get; set; }
        public int? SaldoFinal { get; set; }
        public decimal? SaldoMedioDia { get; set; }
        public int? SaldoFinalAnterior { get; set; }
    }
}
