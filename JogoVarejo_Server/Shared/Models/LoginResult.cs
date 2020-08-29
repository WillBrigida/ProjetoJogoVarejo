using System;

namespace JogoVarejo_Server.Shared.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; } = null;
    }
}