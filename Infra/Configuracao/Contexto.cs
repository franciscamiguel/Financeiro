using Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Configuracao
{
    public class Contexto : DbContext
    {


        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
          //  Database.EnsureCreated();
        }

        public DbSet<Categoria> Categoria { set; get; }
        public DbSet<Despesa> Despesa { set; get; }
        public DbSet<SistemaFinanceiro> SistemaFinanceiro { set; get; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            // ambiene  de desenvolvimento
            string strCon = "Data Source=DESKTOP-FLR1ARP;Initial Catalog=FINANCEIRO;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

          

            return strCon;
        }

    }
}
