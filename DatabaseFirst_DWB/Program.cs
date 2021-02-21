using System;
using System.Linq;
using DatabaseFirst_DWB.DataAccess;

namespace DatabaseFirst_DWB
{
    class Program
    {
        public static void SimpleSelect()
        {
            var dataContext = new NorthwindContext();
            var employeeQuery = dataContext.Employees.Select(s => s);
            var output = employeeQuery.ToList();

            foreach(var employee in output)
            {
                Console.WriteLine($"Nombre: {employee.FirstName}");
            }
        }

        static void Main(string[] args)
        {
            SimpleSelect();
        }
    }
}
