using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cohen.TCC.Dominio
{
    public class Ticket
    {
        public int id_ticket { get; set; }
        public int id_veiculo { get; set; }
        public DateTime dt_entrada { get; set; }
        public DateTime dt_saida { get; set; }
        public double nu_valor { get; set; }

        public virtual Veiculo veiculo { get; set; }
    }
}