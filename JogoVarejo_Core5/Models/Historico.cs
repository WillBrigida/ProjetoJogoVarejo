namespace JogoVarejo_Core5
{
    public class Historico
    {
        public int Dia { get; set; }
        public int Recebido { get; set; }
        public int AReceber { get; set; }
        public int SaldoInicial { get; set; }
        public int Comprado { get; set; }
        public int Prazo { get; set; }
        public int Demanda { get; set; }
        public int Vendido { get; set; }
        public int SaldoFinal { get; set; }
        public decimal SaldoMedioDia { get; set; }
    }
}