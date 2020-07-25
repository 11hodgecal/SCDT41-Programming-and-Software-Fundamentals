using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    class Appointment
    {
        string Treatment;
        double price;

        
        public Dentist dentist;
        public Room room;
        public List<string> notes = new List<string>();

        public string Treatment1 { get => Treatment; set => Treatment = value; }
        public double Price { get => price; set => price = value; }

        public Appointment(string treatment, double price, Dentist dentist, Room room)
        {
            Treatment = treatment;
            this.price = price;
            this.dentist = dentist;
            this.room = room;
        }
    }
}
