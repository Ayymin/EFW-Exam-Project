using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Car
    {
        public Car() 
        {
        }

        public Car(string numberPlate)
        {
            this.NumberPlate = numberPlate;
        }


        public int CarID { get; set; }
        public string NumberPlate { get; set; }

        public int FerryID { get; set; }

        public Ferry Ferry { get; set; }

        public List<Guest> guests { get; set; }

        public override string ToString()
        {
            return NumberPlate + " ";
        }



    }
}
