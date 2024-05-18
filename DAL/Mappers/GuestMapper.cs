using Eksamensprojekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Mappers
{
    internal class GuestMapper
    {
        public static DTO.Model.Guest Map(Guest g)
        {
            return new DTO.Model.Guest{FerryId = g.FerryId, Name = g.Name, Age = g.Age, Gender = g.Gender, IsDriver = g.IsDriver, CarId = g.CarId};
        }

        public static Guest Map(DTO.Model.Guest g)
        {
            return new Guest { FerryId = g.FerryId, Name = g.Name, Age = g.Age, Gender = g.Gender, IsDriver = g.IsDriver, CarId = g.CarId };
        }
    }
}
