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
        public Car getcar(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return CarRepository.getCar(id);
        }

        public void AddCar(Car car)
        {
            CarRepository.addCar(car);
        }


        public List<Car> getAllCars(int id)
        {
            return CarRepository.getAllCars(id);
        }

        
          
           

    }
}
