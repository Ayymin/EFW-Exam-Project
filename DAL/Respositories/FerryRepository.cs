using DAL.Context;
using DAL.Mappers;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respositories
{
    public class FerryRepository
    {
        public static Ferry getFerry(int id)
        {
            using (FerryContext context = new FerryContext())
            {
                Eksamensprojekt.Model.Ferry ferry = context.Ferries.Find(id);
                return FerryMapper.Map(context.Ferries.Find(id));
            }
        }

        public static void addFerries(Ferry ferry)
        {
            using (FerryContext context = new FerryContext())
            {
                context.Ferries.Add(FerryMapper.Map(ferry));
                context.SaveChanges();
            }
        }


        public static List<Ferry> GetAllFerries()
        {
            using (FerryContext context = new FerryContext())
            {
                return context.Ferries.Select(FerryMapper.Map).ToList();
            }
        }

    }
}
