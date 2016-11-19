using Cohen.Comum.Entity;
using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cohen.TCC.AcessoDados.Entity.TypeConfiguration
{
    public class ClienteTypeConfiguration : CohenEntityAbstractConfig<Cliente>
    {

        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id_cliente)
               .IsRequired()
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
               .HasColumnName("ID_CLIENTE");

            Property(p => p.id_tipo_cliente)
                .IsRequired()
                .HasColumnName("ID_TIPO_CLIENTE");

            Property(p => p.nm_email)
                .IsRequired()
                .HasColumnName("NM_EMAIL");

            Property(p => p.nm_cliente)
                .IsRequired()
                .HasColumnName("NM_CLIENTE");

            Property(p => p.cnh_cliente)
                .IsRequired()
                .HasColumnName("CNH_CLIENTE");
            Property(p => p.dt_cadastro)
                .IsRequired()
                .HasColumnName("DT_CADASTRO");

            Property(p => p.dt_inativo)
                .HasColumnName("DT_INATIVO")
                 .IsOptional();



        }


        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.id_cliente);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasKey(pk => pk.id_tipo_cliente);



        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("CLIENTE");
        }
    }
}