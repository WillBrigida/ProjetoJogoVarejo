using System;
using Microsoft.AspNetCore.Identity;
namespace JogoVarejoServer.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeGrupo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}