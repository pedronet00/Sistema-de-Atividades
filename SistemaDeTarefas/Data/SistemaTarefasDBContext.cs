using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options)
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<LivroModel> Livro { get; set; }
        public DbSet<TipoAtividadeModel> TipoAtividade { get; set; }
        public DbSet<LocalAtividadeModel> LocalAtividade { get; set; }
        public DbSet<AtividadeModel> Atividade { get; set; }
        public DbSet<PostModel> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new TipoAtividadeMap());
            modelBuilder.ApplyConfiguration(new LocalAtividadeMap());
            modelBuilder.ApplyConfiguration(new AtividadeMap());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AtividadeModel>()
            .HasOne(a => a.LocalAtividade)
            .WithMany()  // Supondo que um Local possa estar em várias atividades
            .HasForeignKey(a => a.localAtividade);

            modelBuilder.Entity<AtividadeModel>()
            .HasOne(a => a.TipoAtividade)
            .WithMany()  // Supondo que um Local possa estar em várias atividades
            .HasForeignKey(a => a.tipoAtividade);
        }
    }
}
