using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class Veiculo
    {
        [Required]
        [Display(Name = "ID do Veículo")]
        public int id_veiculo { get; set; }
        [Required]
        [Display(Name = "ID do Tipo Veículo")]
        public int id_tipo_veiculo { get; set; }
                [Required]
        [Display(Name = "ID do Tipo Veículo")]
        public int id_cliente { get; set; }
        [Required(ErrorMessage = "Placa Obrigatória")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Placa Do veiculo Invalido")]
        [Display(Name = "Placa")]
        public string nu_placa { get; set; }
        [Display(Name = "Ano")]
        public int dt_ano { get; set; }
        [Display(Name = "Cor")]
        public string nm_cor { get; set; }
        [Display(Name = "Porta")]
        public int nu_porta { get; set; }
        [Display(Name = "Data do Cadastro")]
        public DateTime dt_cadastro { get; set; }
        [Display(Name = "Data do Inativo")]
        public DateTime dt_inativo { get; set; }

        public virtual ICollection<Ticket> ticket { get; set; }
        public virtual TipoVeiculo tipo_veiculo { get; set; }
        public virtual Cliente cliente { get; set; }



    }
}