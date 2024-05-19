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
        public Ferry GetFerry(int id)
        {
            if(id < 0) throw new IndexOutOfRangeException();
            return FerryRepository.GetFerry(id);
        }

        public  void AddFerry(Ferry ferry)
        {
            FerryRepository.AddFerries(ferry);
        }

        public List<Ferry> GetAllFerries() 
        {
            return FerryRepository.GetAllFerries();

        }

        public Ferry UpdateFerryPassengerAmount(Ferry ferry)
        {
            return FerryRepository.UpdateFerry(ferry);
        }

        public static Ferry UpdateFerryCarAmount(Ferry ferry)
        {
            return FerryRepository.UpdateFerry(ferry);
        }

        public int CalculateFerryPrice(Ferry ferry)
        {
            return (ferry.AmountofPassengers * ferry.GuestPrice) + (ferry.AmountofCars * ferry.CarPrice);
        }

        public void UpdateFerry(Ferry ferry)
        {
            FerryRepository.UpdateFerry(ferry);

        }

        public void UpdateFerryObject(Ferry ferry)
        {
            FerryRepository.UpdateFerryObject(ferry);
        }
    }
}
