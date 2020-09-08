using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Shared.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public int GrupoUsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Grupo Grupo { get; set; }
    }
}
