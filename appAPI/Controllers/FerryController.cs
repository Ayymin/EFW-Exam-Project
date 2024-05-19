using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DTO.Model;


using System.Web.Http;
using System.Web.Http.Cors;
using Eksamensprojekt.Model;
using BusinessLogic.BLL;
using DAL.Respositories;


namespace appAPI.Controllers
{
    public class FerryController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public DTO.Model.Ferry GetFerry(int id)
        {
            FerryBLL bll = new FerryBLL();
            return bll.GetFerry(id);
        }
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
      
        [HttpPost]
        public void AddFerry(DTO.Model.Ferry ferry) 
        {
          FerryRepository.AddFerries(ferry);
        
        }
    }
}
