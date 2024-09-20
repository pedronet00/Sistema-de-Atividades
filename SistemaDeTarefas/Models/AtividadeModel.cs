namespace SistemaDeTarefas.Models
{
    public class AtividadeModel
    {

        public string Id { get; set; }

        public string tituloAtividade { get; set; }

        public string descricaoAtividade { get; set; }

        public string localAtividade { get; set; }

        public DateTime dataAtividade { get; set; }

        public int tipoAtividade { get; set; }
    }
}
