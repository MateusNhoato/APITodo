using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiTodo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }
        [DefaultValue(false)]
        public bool Concluida { get; set; }
    }
}
