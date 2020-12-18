using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            Employee employee1 = new Employee(170, "Sam");
            Employee employee2 = new Employee(230, "Sammy");
            Employee employee3 = new Employee(320, "Samuel");
            Employee employee4 = new Employee(450, "Samantha");

            employees.Add(1, employee1);
            employees.Add(2, employee2);
            employees.Add(3, employee3);
            employees.Add(4, employee4);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Key);
                Console.WriteLine("Employee info below");
                Console.WriteLine(employee.Value.Id);
                Console.WriteLine(employee.Value.EmployeeName);
            }

            foreach (var employee in employees.Keys)
            {
                Console.WriteLine(employee);
            }

            foreach (var employee in employees.Values)
            {
                Console.WriteLine(employee.EmployeeName);
            }

            Console.ReadKey();
        }
    }
}
