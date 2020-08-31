using System;

namespace JogoVarejo_Server.Shared.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public string Mensagem { get; set; } = null;
        public bool Sucesso { get; set; }
        public DateTime? DataExpiracao { get; set; } = null;
    }
}