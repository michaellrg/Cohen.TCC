using Cohen.TCC.AcessoDados.Entity.Migrations;
using Cohen.TCC.AcessoDados.Entity.TypeConfiguration;
using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Cohen.TCC.AcessoDados.Entity.Context
{
    public class TCCDbContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<TipoCliente> tp_clientes { get; set; }
        public DbSet<TipoUsuario> tp_usuarios { get; set; }
        public DbSet<TipoVeiculo> tp_veiculos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Veiculo> veiculos { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Preco> precos { get; set; }


        public void TCCDBContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Properties<TimeSpan>().Configure(c => c.HasColumnType("time"));
            modelBuilder.Configurations.Add(new ClienteTypeConfiguration());
            modelBuilder.Configurations.Add(new TipoClienteTypeConfiguration());
            modelBuilder.Configurations.Add(new TipoUsuarioTypeConfiguration());
            modelBuilder.Configurations.Add(new TipoVeiculoTypeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioTypeConfiguration());
            modelBuilder.Configurations.Add(new TicketTypeConfiguration());
            modelBuilder.Configurations.Add(new PrecoTypeConfiguration());
            modelBuilder.Configurations.Add(new VeiculoTypeConfiguration());

        }
    }
}