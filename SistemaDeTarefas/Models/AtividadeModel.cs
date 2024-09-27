namespace SistemaDeTarefas.Models
{
    public class AtividadeModel
    {

        public string Id { get; set; }

        public string tituloAtividade { get; set; }

        public string descricaoAtividade { get; set; }

        public int idLocalAtividade { get; set; }
        public LocalAtividadeModel LocalAtividade { get; set; }

        public DateTime dataAtividade { get; set; }

        public int idTipoAtividade { get; set; }
        public TipoAtividadeModel TipoAtividade { get; set; }
    }
}
