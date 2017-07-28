using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Modelo.Entity;

namespace Modelo
{
    public class ContextManager:DbContext
    {
        public ContextManager(): base("Conection")
        {
            Database.SetInitializer<ContextManager>(new CreateDatabaseIfNotExists<ContextManager>());   
        }
        public DbSet<ContractRenewals> Contracts { get; set; }

        public DbSet<Pending> Pending { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<Forecast> Forecast { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
