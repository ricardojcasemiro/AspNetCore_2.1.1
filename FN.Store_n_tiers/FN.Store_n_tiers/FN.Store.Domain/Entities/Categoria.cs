using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FN.Store.Domain.Entities
{
    [Table(nameof(Categoria))] // Pega o nome da classe pra criar a tabela
    public class Categoria : Entity
    {        
        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; } /// = new List<Produto>(); // quando se quer add um produto na categoria na inicialização
    }
}