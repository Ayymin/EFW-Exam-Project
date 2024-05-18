using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class Car
    {
        public Car()
        {
        }

        public Car(string numberPlate, int amountOfPassengers)
        {
            this.NumberPlate = numberPlate;
            this.AmountOfPassengers = amountOfPassengers;
         
        }

        public int CarID { get; set; }

        public int GuestId {  get; set; }

        public string NumberPlate { get; set; }

        public int FerryID { get; set; }

        public int AmountOfPassengers { get; set; }



        public override string ToString()
        {
            return NumberPlate + " ";

        }


    }
}
