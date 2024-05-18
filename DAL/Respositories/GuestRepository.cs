using DAL.Context;
using DAL.Mappers;
using DTO.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respositories
{
    public class GuestRepository
    {
        public static Guest GetGuest(int id)
        {
            using (FerryContext context = new FerryContext())
            {
               
                return GuestMapper.Map(context.Guests.Find(id));
            }
        }

        public static void AddGuest(Guest guest)
        {
            using (FerryContext context = new FerryContext())
            {
                context.Guests.Add(GuestMapper.Map(guest));
                context.SaveChanges();
            }
        }

        public static void RemoveGuest(int id) 
        {
            using (FerryContext context = new FerryContext())
            {
               
                var guestToRemove = context.Guests.Find(id);
                context.Guests.Remove(guestToRemove);
                context.SaveChanges();
            }
        
        }


        public static List<Guest> GetAllGuests()
        {
            using (FerryContext context = new FerryContext())
            {
                return context.Guests.Select(GuestMapper.Map).ToList();
            }
        }

        public static List<DTO.Model.Guest> GetAllGuestsFromFerry(int ferryId)
        {
            using (FerryContext context = new FerryContext())
            {
                
                List<Eksamensprojekt.Model.Guest> dalList = context.Guests.ToList();
                List<DTO.Model.Guest> myDTO = new List<DTO.Model.Guest>();
                foreach(Eksamensprojekt.Model.Guest g in dalList)
                {
                    if(g.FerryId == ferryId)
                    {
                        myDTO.Add(GuestMapper.Map(g));
                    }

                }
                return myDTO;
            }
        }







    }
}
