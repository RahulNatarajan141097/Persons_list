using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persons_list.Data
{
    public class DataContext : System.Data.Entity.DbContext
    {
        public virtual System.Data.Entity.DbSet<Persons> Persons { get; set; }
        public virtual System.Data.Entity.DbSet<RegisterPersons> RegisterPersons { get; set; }
        public DataContext() : base("name=CenturyFenceEstimatorEntities")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }        
    }
}
