using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Ferry
    {
        public Ferry()
        {
        }

        public Ferry(string ferryName, int guestPrice, int carPrice)
        {
            this.FerryName = ferryName; 
            this.GuestPrice = guestPrice;
            this.CarPrice = carPrice;
            CarCargo = new List<Car>();
            GuestCargo = new List<Guest>();
        }

        public Ferry(int id, string ferryName, int guestPrice, int carPrice)
        {
            this.Id = id;
            this.FerryName = ferryName;
            this.GuestPrice = guestPrice;
            this.CarPrice = carPrice;
            CarCargo = new List<Car>();
            GuestCargo = new List<Guest>();

        }

        public int Id { get; set; }

        public string FerryName { get; set;}

        public int GuestPrice { get; set;}

        public int CarPrice { get; set;}

        public List<Car> CarCargo { get; set; }

        public List<Guest> GuestCargo { get; set; }

        public override string ToString()
        {
            return FerryName;
        }
    }
}
