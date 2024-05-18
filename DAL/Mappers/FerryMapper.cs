using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamensprojekt.Model;

namespace DAL.Mappers
{
    internal class FerryMapper
    {

        public static DTO.Model.Ferry Map(Ferry ferry)
        {
            return new DTO.Model.Ferry(ferry.Id, ferry.FerryName, ferry.GuestPrice, ferry.CarPrice, ferry.AmountofPassengers, ferry.AmountofCars);
        }

        public static Ferry Map(DTO.Model.Ferry ferry)
        {
            return new Ferry(ferry.Id, ferry.FerryName, ferry.GuestPrice, ferry.CarPrice, ferry.AmountofPassengers, ferry.AmountofCars);
        }
    }
}
