using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Models
{
    [Table("tbProduto")]
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string Tipo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
