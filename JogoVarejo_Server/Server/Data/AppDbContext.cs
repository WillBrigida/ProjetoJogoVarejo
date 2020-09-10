using JogoVarejo_Server.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace JogoVarejo_Server.Server.Data
{
    public /*partial*/ class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public AppDbContext()
        {

        }

        //public DbSet<Controle> T_controle { get; set; }
        //public DbSet<Grupo> T_grupo{ get; set; }
        //public DbSet<Teste> T_teste{ get; set; }

        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Controle> Controles { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Movimento> Movimentos { get; set; }
        public virtual DbSet<Sorteado> Sorteados { get; set; }
        public virtual DbSet<VwIndicadore> VwIndicadores { get; set; }
        public virtual DbSet<VwMovimento> VwMovimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JogoVarejo_db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.CompraId).HasColumnName("CompraID");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");
            });

            modelBuilder.Entity<Controle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Controle");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.CustoFixoDiario)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.CustoUnitarioEstocar)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.CustoUnitarioFrete)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.DemandaMediaDiária)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.GanhoUnitario)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.PrecoCompra)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.PrecoVenda)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.GrupoId).ValueGeneratedNever();

                entity.Property(e => e.Quando)
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.Property(e => e.Quanto)
                    .HasMaxLength(800)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.MovimentoId).HasColumnName("MovimentoID");

                entity.Property(e => e.Areceber).HasColumnName("AReceber");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.SaldoMedioDia)
                    .HasColumnType("decimal(5, 1)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 1)");
            });

            modelBuilder.Entity<Sorteado>(entity =>
            {
                entity.HasKey(x => x.Dia);

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.Dia).ValueGeneratedNever();
            });

            modelBuilder.Entity<VwIndicadore>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwIndicadores");

                entity.Property(e => e.CapitalEstoqueMaximo)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.CapitalEstoqueMedio)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.CoberturaEstoqueMaximo)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.CoberturaEstoqueMedio)
                    .HasColumnType("decimal(5, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 2)");

                entity.Property(e => e.CustoEstocar)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.CustoFixo)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.CustoFrete)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.CustoGerenciado)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.DemandaMedia)
                    .HasColumnType("decimal(4, 1)")
                    .HasAnnotation("Relational:ColumnType", "decimal(4, 1)");

                entity.Property(e => e.EstoqueMedio)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.Ganho)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.GanhoPerdido)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.GanhoPotencial)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.Giro)
                    .HasColumnType("decimal(4, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(4, 0)");

                entity.Property(e => e.Lucratividade)
                    .HasColumnType("decimal(5, 1)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 1)");

                entity.Property(e => e.Lucro)
                    .HasColumnType("decimal(5, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 0)");

                entity.Property(e => e.NivelServicoCliente)
                    .HasColumnType("decimal(4, 1)")
                    .HasAnnotation("Relational:ColumnType", "decimal(4, 1)");

                entity.Property(e => e.NivelServiçoSuprimentos)
                    .HasColumnType("decimal(4, 1)")
                    .HasAnnotation("Relational:ColumnType", "decimal(4, 1)");

                entity.Property(e => e.Trmedio)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("TRMedio")
                    .HasAnnotation("Relational:ColumnType", "decimal(4, 2)");
            });

            modelBuilder.Entity<VwMovimento>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMovimentos");

                entity.Property(e => e.Areceber).HasColumnName("AReceber");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.MovimentoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MovimentoID");

                entity.Property(e => e.SaldoMedioDia)
                    .HasColumnType("decimal(5, 1)")
                    .HasAnnotation("Relational:ColumnType", "decimal(5, 1)");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }
}

