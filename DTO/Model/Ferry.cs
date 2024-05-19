using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string FerryName { get; set;}

        [Required]
        public int GuestPrice { get; set;}
        [Required]
        public int CarPrice { get; set;}

        [Range(0, 10, ErrorMessage = "The amount of cars must be between 0 and 10.")]
        public int AmountofCars { get; set; }

        [Range(0, 40, ErrorMessage = "The amount of passengers must be between 0 and 40.")]

        public int AmountofPassengers { get; set; }


        public override string ToString()
        {
            return FerryName;
        }
    }
}
