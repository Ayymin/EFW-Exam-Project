using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DAL.Respositories;

namespace BusinessLogic.BLL
{
    public class FerryBLL
    {
        public static Ferry getFerry(int id)
        {
            if(id < 0) throw new IndexOutOfRangeException();
            return FerryRepository.getFerry(id);
        }

        public static void AddFerry(Ferry ferry)
        {
            FerryRepository.addFerries(ferry);
        }

        public List<Ferry> getAllFerries() 
        {
            return FerryRepository.GetAllFerries();

        }

       


    }
}
