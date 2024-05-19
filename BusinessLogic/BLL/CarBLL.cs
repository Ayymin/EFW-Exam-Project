using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Respositories;
using DTO.Model;

namespace BusinessLogic.BLL
{
    public class CarBLL
    {
        public Car Getcar(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return CarRepository.GetCar(id);
        }

        public void AddCar(Car car)
        {
            CarRepository.AddCar(car);
        }

        public void RemoveCar(int id)
        {
            CarRepository.RemoveCar(id);
        }


        public List<Car> GetAllCars(int id)
        {
            return CarRepository.GetAllCars(id);
        }

        public int GetPassengerAmount(int id)
        {
            return CarRepository.GetPassengerAmount(id);
        }

        public void EditCar(Car car) 
        {
            CarRepository.EditCar(car);
        }
        
          
           

    }
}
