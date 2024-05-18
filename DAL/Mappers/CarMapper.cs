using Eksamensprojekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class CarMapper
    {
        public static DTO.Model.Car Map(Car car)
        {
            return new DTO.Model.Car { NumberPlate = car.NumberPlate, FerryID = car.FerryID, AmountOfPassengers = car.AmountOfPassengers, CarID = car.CarID, GuestId = car.GuestId };
        }

        public static Car Map(DTO.Model.Car car)
        {
            return new Car{ NumberPlate = car.NumberPlate, FerryID = car.FerryID, AmountOfPassengers = car.AmountOfPassengers, CarID = car.CarID, GuestId = car.GuestId };
        }
    }
}
