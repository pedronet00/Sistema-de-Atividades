using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;
namespace SistemaDeTarefas.Data.Map
{
    public class AtividadeMap : IEntityTypeConfiguration<AtividadeModel>
    {
        public void Configure(EntityTypeBuilder<AtividadeModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.tituloAtividade).IsRequired().HasMaxLength(100);
            builder.Property(x => x.descricaoAtividade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.idTipoAtividade).IsRequired().HasMaxLength(1);
            builder.Property(x => x.idLocalAtividade).IsRequired().HasMaxLength(1);
            builder.Property(x => x.dataAtividade).IsRequired();
        }
    }
}
