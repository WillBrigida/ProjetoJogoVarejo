using JogoVarejo_Server.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JogoVarejo_Server.Server.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<Reclamacao> T_reclamacao { get; set; }
        //public DbSet<Funcionario> T_funcionario { get; set; }
        //public DbSet<Morador> T_morador { get; set; }
        //public DbSet<TipoReclamacao> T_tiporeclamacao { get; set; }
    }
}
