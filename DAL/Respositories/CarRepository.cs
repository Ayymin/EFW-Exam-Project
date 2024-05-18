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
        public static DTO.Model.Car getCar(int id)
        {
            using (FerryContext context = new FerryContext())
            {
                return CarMapper.Map(context.Cars.Find(id));
            }
        }

        public static void addCar(DTO.Model.Car car)
        {
            using (FerryContext context = new FerryContext())
            {
                context.Cars.Add(CarMapper.Map(car));
                context.SaveChanges();
            }
        }

        public static List<DTO.Model.Car> getAllCars(int ferryId)
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

    }



}
