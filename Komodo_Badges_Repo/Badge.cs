using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges_Repo
{   
    // This does not have to be done now.
    /*public enum EmployeeType
    {
        Developer = 1,
        Agent,
    }*/

    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
        //public EmployeeType EmployeeType { get; set; } <- Not needed now.

        public Badge() { }

        public Badge(int badgeID, List<string> doors /*EmployeeType employeeType*/)
        {
            BadgeID = badgeID;
            Doors = doors;
            // EmployeeType = employeeType; <- Not needed now.
        }
    }
}