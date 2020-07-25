using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    class Dentist : Staff
    {
        public int staffID = 2;
        public int roomid;
        public bool hasroom = false;
        public int PracID;
        public Dentist(string namee, string users, string password2)
        {
            this.Name = namee;
            this.User = users;
            this.Password1 = password2;
        }
    }
}
