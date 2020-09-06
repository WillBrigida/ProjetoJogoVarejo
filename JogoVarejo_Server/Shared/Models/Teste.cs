using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Shared.Models
{
    public class Teste
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TesteId  { get; set; }
        public int GrupoUsuarioId { get; set; }
        public int GrupoOperadorId { get; set; }
        public string Quando { get; set; }
        public string Quanto { get; set; }
    }
}
