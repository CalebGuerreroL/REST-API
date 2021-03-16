using DatabaseFirst_DWB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Services
{
    public class EmployeeSC : BaseSC
    {
        public IQueryable<Employee> GetAllEmployees()
        {
            return dataContext.Employees;
        }

        public void UpdateEmployeeFirstNameById(string newName, int id = 1)
        {
            var filter = new EmployeeSC.EmployeeFilter();
            var result = filter.FilterBy(GetAllEmployees(), new EmployeeSC.EmFilterId(id));
            var currentEmployee = result.ToList().FirstOrDefault();

            if (currentEmployee == null)
                throw new Exception("No se encontró el empleado con el ID ingresado");

            currentEmployee.FirstName = newName;
            dataContext.SaveChanges();
        }

        public abstract class EmployeeFilterSpecification
        {
            public IQueryable<Employee> Filter(IQueryable<Employee> employees)
            {
                return ApplyFilter(employees);
            }

            protected abstract IQueryable<Employee> ApplyFilter(IQueryable<Employee> employees);
        }

        public class EmployeeFilter
        {
            public IQueryable<Employee> FilterBy(IQueryable<Employee> employees, EmployeeFilterSpecification filter)
            {
                return filter.Filter(employees);
            }
        }

        public class EmFilterName : EmployeeFilterSpecification
        {
            private string name;

            public EmFilterName(string name)
            {
                this.name = name;
            }

            protected override IQueryable<Employee> ApplyFilter(IQueryable<Employee> employees)
            {
                return employees.Where(w => w.FirstName == this.name).Select(s => s);
            }
        }

        public class EmFilterTitle : EmployeeFilterSpecification
        {
            private string title;

            public EmFilterTitle(string title)
            {
                this.title = title;
            }

            protected override IQueryable<Employee> ApplyFilter(IQueryable<Employee> employees)
            {
                return employees.Where(w => w.Title == this.title).Select(s => s);
            }
        }

        public class EmFilterId : EmployeeFilterSpecification
        {
            private int id;

            public EmFilterId(int id)
            {
                this.id = id;
            }

            protected override IQueryable<Employee> ApplyFilter(IQueryable<Employee> employees)
            {
                return employees.Where(w => w.EmployeeId == this.id).Select(s => s);
            }
        }
    }
}
