using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class TipoVeiculo
    {
        [Required]
        public int id_tipo_veiculo { get; set; }

        [Display(Name = "Tipo do Veículo")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        [StringLength(12, MinimumLength =1, ErrorMessage = "Tipo de Invalido")]
        public string nm_tipo { get; set; }
        [Display(Name = "Descrição")]
        public string nm_descricao { get; set; }
        [Display(Name = "Data do Cadastro")]
        public DateTime dt_cadastro { get; set; }
        [Display(Name = "Data do Inativo")]
        public DateTime dt_inativo { get; set; }

        //1:N
        public virtual ICollection<Veiculo> veiculo { get; set; }
    }
}