using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebSystem.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigátorio")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Lembrar-me")]
        public bool RemenberMe { get; set; }
    }
}
