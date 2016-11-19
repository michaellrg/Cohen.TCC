using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class Usuario
    {
        [Required]
        [Display(Name = "ID do Usuário")]
        public int id_usuario { get; set; }
        [Required]
        [Display(Name = "ID do Tipo Usuário")]
        public int id_tipo_usuario { get; set; }
        [Required(ErrorMessage = "Nome Obrigatório")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string nm_email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string nm_senha { get; set; }
        [Display(Name = "Data do Cadastro")]
        public DateTime dt_cadastro { get; set; }
        [Display(Name = "Data do Inativo")]
        public DateTime dt_inativo { get; set; }

        public virtual TipoUsuario tipo_usuario { get; set; }
    }
}