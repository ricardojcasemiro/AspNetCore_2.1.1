using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    [Table(nameof(Usuario))]
    public class Usuario: Entity
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "limite excedido")]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "limite excedido")]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(88, ErrorMessage = "limite excedido")]
        [Column(TypeName = "char(88)")]
        public string Senha { get; set; }
    }
}
