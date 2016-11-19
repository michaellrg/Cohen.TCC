using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class TipoUsuario
    {
        [Required]
        [Display(Name = "ID do Tipo de Usuário")]
        public int id_tipo_usuario { get; set; }
        [Required(ErrorMessage = "Tipo Obrigatório")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Tipo de Invalido")]
        [Display(Name = "Nome")]
        public string nm_nome { get; set; }
        [Display(Name = "Descrição")]
        public string nm_descricao { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime dt_cadastro { get; set; }
        [Display(Name = "Data de Inativo")]
        public DateTime dt_inativo { get; set; }

        public virtual ICollection<Usuario> usuario { get; set; }
    }
}