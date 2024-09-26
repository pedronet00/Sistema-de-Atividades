
namespace SistemaDeTarefas.Models
{
    public class LocalAtividadeModel
    {

        public int Id { get; set; }

        public string localAtividade { get; set; }

        public int statusLocalAtividade { get; set; }

        public static implicit operator LocalAtividadeModel(TipoAtividadeModel v)
        {
            throw new NotImplementedException();
        }
    }
}
