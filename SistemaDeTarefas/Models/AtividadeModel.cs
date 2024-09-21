namespace SistemaDeTarefas.Models
{
    public class AtividadeModel
    {

        public string Id { get; set; }

        public string tituloAtividade { get; set; }

        public string descricaoAtividade { get; set; }

        public int localAtividade { get; set; }
        public LocalAtividadeModel LocalAtividade { get; set; }

        public DateTime dataAtividade { get; set; }

        public int tipoAtividade { get; set; }
        public TipoAtividadeModel TipoAtividade { get; set; }
    }
}
