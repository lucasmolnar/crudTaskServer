using System.ComponentModel.DataAnnotations;

namespace WebApplicationTarefaCrudServer.Entities
{
    public class Tarefa
    {
        public Tarefa()
        {

        }
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
    }
}
