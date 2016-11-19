using Cohen.Comum.Entity;
using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cohen.TCC.AcessoDados.Entity.TypeConfiguration
{
    public class UsuarioTypeConfiguration : CohenEntityAbstractConfig<Usuario>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id_usuario)
              .IsRequired()
              .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
              .HasColumnName("ID_USUARIO");

            Property(p => p.id_tipo_usuario)
                .IsRequired()
                .HasColumnName("ID_TIPO_USUARIO");

            Property(p => p.nm_email)
              .IsRequired()
              .HasColumnName("NM_EMAIL");

            Property(p => p.nm_senha)
                .IsRequired()
                .HasColumnName("NM_SENHA");

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
            HasKey(pk => pk.id_usuario);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasKey(pk => pk.id_tipo_usuario);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("USUARIO");
        }
    }
}