using Cohen.Comum.Entity;
using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cohen.TCC.AcessoDados.Entity.TypeConfiguration
{
    public class PrecoTypeConfiguration : CohenEntityAbstractConfig<Preco>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id_preco)
                 .IsRequired()
                 .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                 .HasColumnName("ID_PRECO");

            Property(p => p.nu_tempo)
               .IsRequired()
               .HasColumnName("NU_TEMPO");

            Property(p => p.nu_valor)
               .IsRequired()
               .HasColumnName("NU_VALOR");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.id_preco);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
           
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("PRECO");

        }
    }
}