using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    public class Nurse : Staff
    {
        public int staffID = 3;
        public bool hasroom = false;

        public Nurse(string namee, string users, string password2)
        {
            this.Name = namee;
            this.User = users;
            this.Password1 = password2;
        }
    }
}
