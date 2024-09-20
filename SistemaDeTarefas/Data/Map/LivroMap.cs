using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<LivroModel>
    {
        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.HasKey(x => x.idLivro);
            builder.Property(x => x.nomeLivro).IsRequired().HasMaxLength(255);
            builder.Property(x => x.autorLivro).IsRequired().HasMaxLength(150);
        }
    }
}
