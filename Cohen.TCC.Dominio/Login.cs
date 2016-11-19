using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class Login
    {
        [Required(ErrorMessage = "Email Inválido")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public virtual string nm_email { get; set; }
        [Required(ErrorMessage = "Senha Inválida")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public virtual string nm_senha { get; set; }
    }
}