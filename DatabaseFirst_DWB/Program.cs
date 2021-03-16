using System;
using System.Linq;
using DatabaseFirst_DWB.DataAccess;
using DatabaseFirst_DWB.Services;

namespace DatabaseFirst_DWB
{
    class Program
    {
        public static EmployeeSC employeeSC = new();
        public static void SimpleSelect()
        {

            var employeeQuery = employeeSC.GetAllEmployees().Select(s => s);
            var output = employeeQuery.ToList();

            output.ForEach(fe => Console.WriteLine($"Nombre: {fe.FirstName}"));
        }

        public static void Extra1(string title)
        {
            var filter = new EmployeeSC.EmployeeFilter();
            var result = filter.FilterBy(employeeSC.GetAllEmployees(), new EmployeeSC.EmFilterTitle(title));
            var output = result.ToList();

            output.ForEach(fe => Console.WriteLine($"Nombre: {fe.FirstName}"));
        }

        public static void Extra2(string newName, int id = 1)
        {
            employeeSC.UpdateEmployeeFirstNameById(newName, id);
        }

        public static void Extra3(string name)
        {
            var filter = new EmployeeSC.EmployeeFilter();
            var result = filter.FilterBy(employeeSC.GetAllEmployees(), new EmployeeSC.EmFilterName(name));
            var output = result.ToList();

            output.ForEach(fe => Console.WriteLine($"Nombre: {fe.FirstName}"));
        }

        static void Main(string[] args)
        {
            //Code
        }
    }
}
