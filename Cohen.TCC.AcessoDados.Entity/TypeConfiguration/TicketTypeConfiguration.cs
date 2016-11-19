using Cohen.Comum.Entity;
using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cohen.TCC.AcessoDados.Entity.TypeConfiguration
{
    public class TicketTypeConfiguration : CohenEntityAbstractConfig<Ticket>
    {
        protected override void ConfigurarCamposTabela()
        {

            Property(p => p.id_ticket)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ID_TICKET");

            Property(p => p.id_veiculo)
               .IsRequired()
               .HasColumnName("ID_VEICULO");

            Property(p => p.dt_entrada)
              .IsRequired()
              .HasColumnName("DT_ENTRADA");

            Property(p => p.dt_saida)
            .IsOptional()
            .HasColumnName("DT_SAIDA");

            Property(p => p.nu_valor)
            .IsOptional()
            .HasColumnName("NU_VALOR");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.id_ticket);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasKey(pk => pk.id_veiculo);
           
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("TICKET");
        }
    }
}