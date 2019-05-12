using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Models
{
    public class SignInVM
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "limite excedido")]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)",
            ErrorMessage = "email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(10, ErrorMessage = "limite excedido")]
        public string Senha { get; set; }

        public string ReturnUrl { get; set; }
    }
}
