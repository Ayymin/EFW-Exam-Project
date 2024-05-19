
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamensprojekt.Model;

namespace DAL.Context
{
    internal class FerryInitializer : CreateDatabaseIfNotExists<FerryContext>
    {
        protected override void Seed(FerryContext context)
        {
            Ferry ferry1 = new Ferry("HMS Queen Lizzy", 99, 197);
            Ferry ferry2 = new Ferry("Titanic", 99, 197);
            context.Ferries.Add(ferry1);
            context.Ferries.Add(ferry2);
            context.SaveChanges();
        }

        private void Dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
        
    }
}
