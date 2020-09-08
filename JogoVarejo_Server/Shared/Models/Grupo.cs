
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoVarejo_Server.Shared.Models
{
    public class Grupo
    {
        [Key]
        public int GrupoId { get; set; }
        public int GrupoUsuarioId { get; set; }
        public int GrupoOperadorId { get; set; }
        public string Quando { get; set; }
        public string Quanto { get; set; }
    }
}