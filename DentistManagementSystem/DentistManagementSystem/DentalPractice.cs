using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    class DentalPractice
    {
        public bool HasReceptionist = false;
        public string Name; 
        public int PracID;
        public Receptionist AssinedRec;
        public List<Room> pracRooms = new List<Room> { };

        public DentalPractice(bool hasReceptionist, string name, int pracID, Receptionist assinedRec)
        {
            HasReceptionist = hasReceptionist;
            Name = name;
            PracID = pracID;
            AssinedRec = assinedRec;
        }
    }
}
