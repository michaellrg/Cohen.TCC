using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class Cliente
    {
        [Required]
        [Display(Name = "ID do Cliente")]
        public int id_cliente { get; set; }

        [Display(Name = "ID do Tipo de Cliente")]
        public int id_tipo_cliente { get; set; }

        [Display(Name = "Nome")]
        [Required (ErrorMessage ="Nome Obrigatório")]
        [StringLength(80, MinimumLength = 15, ErrorMessage = "Número de Caracteres inválido")]
        public string nm_cliente { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string nm_email { get; set; }

        [Display(Name = "CNH")]
        [Required(ErrorMessage ="CNH Inválido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Número de Caracteres inválido")]
        public string cnh_cliente { get; set; }

        [Display(Name = "Data do Cadastro")]
        public DateTime dt_cadastro { get; set; }
        [Display(Name = "Data do Inativo")]
        public DateTime dt_inativo { get; set; }

        public virtual TipoCliente tipo_cliente { get; set; }

       
    }
}