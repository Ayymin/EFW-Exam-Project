using BusinessLogic.BLL;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace appAPI.Controllers
{
    public class GuestController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Guest GetGuest(int id)
        {
            GuestBLL bll = new GuestBLL();
            return bll.GetGuest(id);
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public Guest GetGuestOne() 
        {
            GuestBLL bll = new GuestBLL();
            return bll.GetGuest(1);
        }

        public void AddGuest(Guest guest) 
        {
            GuestBLL bll = new GuestBLL();
            bll.AddGuest(guest);
        }
    }
}
