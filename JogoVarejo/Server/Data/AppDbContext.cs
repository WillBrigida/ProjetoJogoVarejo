using JogoVarejo.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JogoVarejo.Data
{
    public partial class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<Controle> T_controle { get; set; }
        //public DbSet<Grupo> T_grupo{ get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Controle> Controle { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Movimentos> Movimentos { get; set; }
        public virtual DbSet<Sorteados> Sorteados { get; set; }
        public virtual DbSet<VwIndicadorNumeroEncomendas> VwIndicadorNumeroEncomendas { get; set; }
        public virtual DbSet<VwIndicadorQuebrasDeEstoque> VwIndicadorQuebrasDeEstoque { get; set; }
        public virtual DbSet<VwIndicadores> VwIndicadores { get; set; }
        public virtual DbSet<VwIndicadoresMovimentos> VwIndicadoresMovimentos { get; set; }
        public virtual DbSet<VwIndicadoresSuprimentos> VwIndicadoresSuprimentos { get; set; }
        public virtual DbSet<VwMovimentos> VwMovimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JogoVarejo_db2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Compras>(entity =>
        {
            entity.HasKey(e => e.CompraId)
                .HasName("PK__Compras__067DA725E2468A6E");

            entity.Property(e => e.CompraId).HasColumnName("CompraID");

            entity.Property(e => e.GrupoId).HasColumnName("GrupoID");
        });

            modelBuilder.Entity<Controle>(entity =>
            {
                entity.Property(e => e.ControleId).HasColumnName("ControleID");

                entity.Property(e => e.CustoFixoDiario).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CustoUnitarioEstocar).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CustoUnitarioFrete).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DemandaMediaDiária).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.GanhoUnitario).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PrecoCompra).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PrecoVenda).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.GrupoId);

                entity.Property(e => e.GrupoId).ValueGeneratedNever();

                entity.Property(e => e.Quando)
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.Property(e => e.Quanto)
                    .HasMaxLength(800)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimentos>(entity =>
            {
                entity.HasKey(e => e.MovimentoId)
                    .HasName("PK__Moviment__D467F61CD8B39135");

                entity.Property(e => e.MovimentoId).HasColumnName("MovimentoID");

                entity.Property(e => e.Areceber).HasColumnName("AReceber");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.SaldoMedioDia).HasColumnType("decimal(5, 1)");
            });

            modelBuilder.Entity<Sorteados>(entity =>
            {
                entity.HasKey(e => e.Dia);

                entity.Property(e => e.Dia).ValueGeneratedNever();
            });

            modelBuilder.Entity<VwIndicadorNumeroEncomendas>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwIndicadorNumeroEncomendas");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");
            });

            modelBuilder.Entity<VwIndicadorQuebrasDeEstoque>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwIndicadorQuebrasDeEstoque");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");
            });

            modelBuilder.Entity<VwIndicadores>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwIndicadores");

                entity.Property(e => e.CapitalEstoqueMaximo).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CapitalEstoqueMedio).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CoberturaEstoqueMaximo).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CoberturaEstoqueMedio).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CustoEstocar).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CustoFixo).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CustoFrete).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CustoGerenciado).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.DemandaMedia).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.EstoqueMedio).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Ganho).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.GanhoPerdido).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.GanhoPotencial).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Giro).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.Lucratividade).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Lucro).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.NivelServicoCliente).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.NivelServiçoSuprimentos).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Trmedio)
                    .HasColumnName("TRMedio")
                    .HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<VwIndicadoresMovimentos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwIndicadoresMovimentos");

                entity.Property(e => e.DemandaMedia).HasColumnType("decimal(29, 11)");

                entity.Property(e => e.EstoqueMedio).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.Trmedio)
                    .HasColumnName("TRMedio")
                    .HasColumnType("decimal(29, 11)");
            });

            modelBuilder.Entity<VwIndicadoresSuprimentos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwIndicadoresSuprimentos");

                entity.Property(e => e.CustoFrete).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.NivelServiçoSuprimentos).HasColumnType("numeric(33, 11)");
            });

            modelBuilder.Entity<VwMovimentos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMovimentos");

                entity.Property(e => e.Areceber).HasColumnName("AReceber");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.MovimentoId)
                    .HasColumnName("MovimentoID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SaldoMedioDia).HasColumnType("decimal(5, 1)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}