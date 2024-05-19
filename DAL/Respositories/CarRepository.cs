using DAL.Context;
using DAL.Mappers;
using DTO.Model;
using Eksamensprojekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Respositories
{
    public class CarRepository
    {
        public static DTO.Model.Car GetCar(int id)
        {
            using (FerryContext context = new FerryContext())
            {
                return CarMapper.Map(context.Cars.Find(id));
            }
        }

        public static void AddCar(DTO.Model.Car car)
        {
            using (FerryContext context = new FerryContext())
            {
                var existingFerry = context.Ferries.Find(car.FerryID);
                existingFerry.AmountofCars++;
                existingFerry.AmountofPassengers += car.AmountOfPassengers;
                context.Cars.Add(CarMapper.Map(car));
                context.SaveChanges();
            }
        }

        public static void RemoveCar(int id)
        {
            using (FerryContext context = new FerryContext())
            {
                var carToRemove = context.Cars.Find(id);
                context.Cars.Remove(carToRemove);
                context.SaveChanges();
            }
        }


        public static List<DTO.Model.Car> GetAllCars(int ferryId)
        {
            using (FerryContext context = new FerryContext())
            {
                List<Eksamensprojekt.Model.Car> dalList = context.Cars.ToList();
                List<DTO.Model.Car> myDTO = new List<DTO.Model.Car>();
                foreach(Eksamensprojekt.Model.Car c in dalList)
                {
                    if(c.FerryID == ferryId)
                    {
                        myDTO.Add(CarMapper.Map(c));
                    }
                }
                return myDTO;
            }

        }

        public static int GetPassengerAmount(int carId)
        {
            using (FerryContext context = new FerryContext())
            {
                var car = context.Cars.Find(carId);
                return car.AmountOfPassengers;
            }
        }

        
        public static void EditCar(DTO.Model.Car car)
        {
            using (FerryContext context = new FerryContext())
            {
                var oldCar = context.Cars.Find(car.CarID);
                oldCar.NumberPlate = car.NumberPlate;
                oldCar.AmountOfPassengers = car.AmountOfPassengers;
                context.SaveChanges();

            }

        }

    }



}
