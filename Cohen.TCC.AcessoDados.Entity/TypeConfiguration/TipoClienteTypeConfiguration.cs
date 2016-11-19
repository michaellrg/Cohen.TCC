using Cohen.Comum.Entity;
using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cohen.TCC.AcessoDados.Entity.TypeConfiguration
{
    public class TipoClienteTypeConfiguration : CohenEntityAbstractConfig<TipoCliente>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id_tipo_cliente)
              .IsRequired()
              .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
              .HasColumnName("ID_TIPO_CLIENTE");

            Property(p => p.nm_tipo)
                .IsRequired()
                .HasColumnName("NM_TIPO");


            Property(p => p.nm_descricao)
                .HasColumnName("NM_DESCRICAO");

            Property(p => p.dt_cadastro)
                 .IsRequired()
                 .HasColumnName("DT_CADASTRO");

            Property(p => p.dt_inativo)
                .HasColumnName("DT_INATIVO")
                 .IsOptional();

        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.id_tipo_cliente);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {

        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("TIPO_CLIENTE");
        }
    }
}