using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;
namespace SistemaDeTarefas.Data.Map
{
    public class TipoAtividadeMap : IEntityTypeConfiguration<TipoAtividadeModel>
    {
        public void Configure(EntityTypeBuilder<TipoAtividadeModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.tipoAtividade).IsRequired().HasMaxLength(255);
        }
    }
}
