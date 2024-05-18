using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DAL.Respositories;

namespace BusinessLogic.BLL
{
    public class GuestBLL
    {
        public Guest GetGuest(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return GuestRepository.GetGuest(id);
        }

        public void AddGuest(Guest guest) 
        {
            GuestRepository.AddGuest(guest);
        }

        public void RemoveGuest(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();

           GuestRepository.RemoveGuest(id);
        }

        public List<Guest> GetGuests()
        {
            return GuestRepository.GetAllGuests();

        }

        public List<Guest> GetAllGuests(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return GuestRepository.GetAllGuests();
        }
    }
}
