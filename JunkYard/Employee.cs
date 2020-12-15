using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }

        public Employee(int id, string employeeName)
        {
            Id = id;
            EmployeeName = employeeName;
        }
    }
}
