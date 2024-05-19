using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DTO.Model;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessLogic.BLL;

namespace appAPI.Controllers
{
    public class CarController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Car GetEmployee(int id)
        {
            CarBLL bll = new CarBLL();
            return bll.Getcar(id);
        }
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Car GetEmployeeOne()
        {
            CarBLL bll = new CarBLL();
            return bll.Getcar(1);
        }
        [HttpPost]
        public void AddCar(Car car)
        {
            CarBLL bll = new CarBLL();
            bll.AddCar(car);
        }
    }
}
