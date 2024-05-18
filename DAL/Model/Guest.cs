﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eksamensprojekt.Model
{ 
       public class Guest
        {
        public Guest()
        {
        }

        

        public Guest(string name, int age, string gender, bool isDriver)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.IsDriver = isDriver;
        }

        public int GuestID { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public int FerryId { get; set; }
        

        public bool IsDriver { get; set; }

        public override string ToString()
        {
            return Name + " " + FerryId + " ";
        }

    }

    }


