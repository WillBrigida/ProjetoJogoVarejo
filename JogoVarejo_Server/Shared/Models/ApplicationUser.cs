﻿using Microsoft.AspNetCore.Identity;
using System;

namespace JogoVarejo_Server.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int TipoUsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
