using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class TipoCliente
    {
        [Required]
        [Display(Name = "ID do Tipo de Cliente")]
        public int id_tipo_cliente { get; set; }
        [Required(ErrorMessage = "Nome Obrigatório")]
        [StringLength(15, MinimumLength =5, ErrorMessage = "Tipo de Invalido")]
        [Display(Name = "Tipo")]
        public string nm_tipo { get; set; }
        [Display(Name = "Descrição")]
        public string nm_descricao { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime dt_cadastro { get; set; }
        [Display(Name = "Data do Inativo")]
        public DateTime dt_inativo { get; set; }


        //1:N
        public virtual ICollection<Cliente> cliente { get; set; }
    }
}