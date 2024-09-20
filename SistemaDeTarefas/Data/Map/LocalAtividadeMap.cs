using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;
namespace SistemaDeTarefas.Data.Map
{
    public class LocalAtividadeMap : IEntityTypeConfiguration<LocalAtividadeModel>
    {
        public void Configure(EntityTypeBuilder<LocalAtividadeModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.localAtividade).IsRequired().HasMaxLength(255);
        }
    }
}
