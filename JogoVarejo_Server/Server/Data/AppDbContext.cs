using JogoVarejo_Server.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace JogoVarejo_Server.Server.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Controle> T_controle { get; set; }
        public DbSet<Grupo> T_grupo{ get; set; }
        public DbSet<Teste> T_teste{ get; set; }
        //public DbSet<Controle> T_controle2 { get; set; }
        //public DbSet<Funcionario> T_funcionario { get; set; }
        //public DbSet<Morador> T_morador { get; set; }
        //public DbSet<TipoReclamacao> T_tiporeclamacao { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ApplicationUser>()
        //     .HasOne(i => i.Grupo)
        //     .WithOne(c => c.ApplicationUser)
        //     .IsRequired()
        //     .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
