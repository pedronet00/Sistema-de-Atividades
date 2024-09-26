namespace SistemaDeTarefas.Models
{
    public class PostModel
    {

        public int Id { get; set; }

        public string tituloPost { get; set; }

        public string descricaoPost { get; set; }

        public string textoPost { get; set; }

        public DateTime dataPost { get; set; }

        public int autorPost {  get; set; }
    }
}
