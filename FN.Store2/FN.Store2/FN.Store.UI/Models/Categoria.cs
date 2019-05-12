using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Models
{
    [Table(nameof(Categoria))] // Pega o nome da classe pra criar a tabela
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; } /// = new List<Produto>(); // quando se quer add um produto na categoria na inicialização
    }
}
