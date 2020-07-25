using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    class Patient
    {
        string Name;
        int number;
        string Email;
        string Address;
        bool Gender;
        bool HasDentist;
        Dentist Dentist;
        public int pracid;
        

        public List<Appointment> PatientAppointments = new List<Appointment>();

        public Patient(string name, int number, string email, bool gender, bool hasDentist, Dentist dentist , int Pracid , string address)
        {
            Name = name;
            this.number = number;
            Email = email;
            Gender = gender;
            HasDentist = hasDentist;
            Dentist = dentist;
            pracid = Pracid;
            Address = address;
        }

        public string Name1 { get => Name; set => Name = value; }
        public int Number { get => number; set => number = value; }
        public string Email1 { get => Email; set => Email = value; }
        public bool Gender1 { get => Gender; set => Gender = value; }
        public bool HasDentist1 { get => HasDentist; set => HasDentist = value; }
        internal Dentist Dentist1 { get => Dentist; set => Dentist = value; }
        public int pracid1 { get => pracid; set => pracid = value; }
        public string Address1 { get => Address; set => Address = value; }
    }
}
