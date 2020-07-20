using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    class Admin : Staff
    {
        public int staffID = 0;
        public Admin(string namee, string users, string password2)
        {
            this.Name = namee;
            this.User = users;
            this.Password1 = password2;
        }
    }
}
