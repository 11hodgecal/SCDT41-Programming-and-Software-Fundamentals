 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    class Room
    {
        public int roomid;
        public bool hasDentist = false;
        public bool hasNurse = false;
        public Nurse assinednur;
        public Dentist assineddent;

        public Room(int roomid, bool hasDentist, bool hasNurse, Nurse assinednur, Dentist assineddent)
        {
            this.roomid = roomid;
            this.hasDentist = hasDentist;
            this.hasNurse = hasNurse;
            this.assinednur = assinednur;
            this.assineddent = assineddent;
        }
    }
}
