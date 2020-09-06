namespace JogoVarejo_Server.Shared.Models
{
    public class Grupo
    {
        public int GrupoId { get; set; }
        public int GrupoOperadorId { get; set; }
        public string Quando { get; set; }
        public string Quanto { get; set; }
        ApplicationUser ApplicationUser { get; set; }
    }
}