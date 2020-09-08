
using System.ComponentModel.DataAnnotations;

namespace JogoVarejo.Shared.Models
{
    public class Grupo
    {
        [Key]
        public int GrupoId { get; set; }
        public int GrupoUsuarioId { get; set; }
        public string GrupoUsuarioNome { get; set; }
        public int OperadorId { get; set; }
        public string Quando { get; set; }
        public string Quanto { get; set; }
    }
}