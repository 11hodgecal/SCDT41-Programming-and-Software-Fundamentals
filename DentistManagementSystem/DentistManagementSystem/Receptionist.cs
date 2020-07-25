using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    public class Receptionist : Staff
    {
        public int staffID = 1;
        public int PracID;
        public bool isassined = false;


        public Receptionist(string namee, string users, string password2)
        {
            this.Name = namee;
            this.User = users;
            this.Password1 = password2;
        }

        
        
    }
}
