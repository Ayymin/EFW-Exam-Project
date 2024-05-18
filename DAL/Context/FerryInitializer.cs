
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
            Ferry ferry1 = new Ferry("HMS Queen Lizzy", 100, 200);
            Ferry ferry2 = new Ferry("Titanic", 100, 200);
            //guest amin = new guest("amin", 23, "m", true);
            //amin.ferryid = ferry1.id;


            //car mikkelsbil = new car("1234-56");
            //mikkelsbil.ferryid = ferry1.id;
            //amin.carid = mikkelsbil.carid;
            //ferry1.carcargo.add(mikkelsbil);




            //amin.ferry = ferry1;
            context.Ferries.Add(ferry1);
            context.Ferries.Add(ferry2);
            //context.Guests.Add(amin);
            //context.Cars.Add(mikkelsBil);

            context.SaveChanges();

        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
        
    }
}
