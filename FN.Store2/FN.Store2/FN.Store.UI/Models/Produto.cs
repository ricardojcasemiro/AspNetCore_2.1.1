using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Models
{

    //[Table("tbProduto")]
    [Table(nameof(Produto))]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="campo obrigatório")]
        [StringLength(100, ErrorMessage ="limite excedido")]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "money")]
        //[DataType(DataType.Currency)]
        [Display(Name ="Preço")]
        public decimal Preco { get; set; }

        //[Required(ErrorMessage = "campo obrigatório")]
        //[Column(TypeName = "varchar(50)")]
        //public string Tipo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "opção inválida")]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
    }
}
