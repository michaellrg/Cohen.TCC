using Cohen.Comum.Entity;
using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cohen.TCC.AcessoDados.Entity.TypeConfiguration
{
    public class VeiculoTypeConfiguration : CohenEntityAbstractConfig<Veiculo>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id_veiculo)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ID_VEICULO");

            Property(p => p.id_tipo_veiculo)
               .IsRequired()
               .HasColumnName("ID_TIPO_VEICULO");

            Property(p => p.id_cliente)
              .IsRequired()
              .HasColumnName("ID_CLIENTE");

            Property(p => p.nu_placa)
               .IsRequired()
               .HasColumnName("NU_PLACA");

            Property(p => p.dt_ano)
              .IsRequired()
              .HasColumnName("DT_ANO");

            Property(p => p.nm_cor)
              .IsRequired()
              .HasColumnName("NM_COR");

            Property(p => p.nu_porta)
               .IsRequired()
               .HasColumnName("NU_PORTA");

            Property(p => p.dt_cadastro)
                .IsRequired()
                .HasColumnName("DT_CADASTRO");

            Property(p => p.dt_inativo)
                .IsOptional()
                .HasColumnName("DT_INATIVO")
                .IsOptional();
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.id_veiculo);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasKey(pk => pk.id_tipo_veiculo);
            HasKey(pk => pk.id_cliente);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("VEICULO");
        }
    }
}