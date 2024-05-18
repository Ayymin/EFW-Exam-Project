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
        public Guest getGuest(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return GuestRepository.getGuest(id);
        }

        public void addGuest(Guest guest) 
        {
            GuestRepository.addGuest(guest);
        
        }

        public List<Guest> GetGuests()
        {
            return GuestRepository.getAllGuests();

        }

        public List<Guest> GetAllGuests(int Id)
        {
            return GuestRepository.getAllGuests();
        }
    }
}
