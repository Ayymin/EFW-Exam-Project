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

        }

        public Ferry(int id, string ferryName, int guestPrice, int carPrice, int amountofPassengers, int amountofCars)
        {
            this.Id = id;
            this.FerryName = ferryName;
            this.GuestPrice = guestPrice;
            this.CarPrice = carPrice;
            this.AmountofPassengers = amountofPassengers;
            this.AmountofCars = amountofCars;

        }

        public int Id { get; set; }

        public string FerryName { get; set;}

        public int GuestPrice { get; set;}

        public int CarPrice { get; set;}

        public int AmountofCars { get; set; }

        public int AmountofPassengers { get; set; }


        public override string ToString()
        {
            return FerryName;
        }
    }
}
