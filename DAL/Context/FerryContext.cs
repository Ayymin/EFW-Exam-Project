using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Eksamensprojekt.Model;
using System.Reflection.Emit;

namespace DAL.Context
{
    internal class FerryContext : DbContext
    {
        public FerryContext()  : base("Ferries")
        {
        
        }

        public DbSet<Ferry> Ferries { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}
