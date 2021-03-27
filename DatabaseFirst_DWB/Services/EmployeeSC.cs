using DatabaseFirst_DWB.DataAccess;
using DatabaseFirst_DWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Services
{
    public class EmployeeSC : BaseSC, IActions<Employee, EmployeeDTO, int>
    {
        public IQueryable<Employee> GetAll()
        {
            return dataContext.Employees;
        }

        public Employee Get(int id)
        {
            var employee = GetAll().FirstOrDefault(fd => fd.EmployeeId == id);

            if (employee == null)
                throw new ArgumentException($"El empleado con el id: {id} no fue encontrado");

            return employee;
        }

        public void Add(EmployeeDTO obj)
        {
            try
            {
                var newEmployee = new Employee()
                {
                    FirstName = obj.Name,
                    LastName = obj.FamilyName,
                    Title = obj.Tag,
                    Address = obj.Address
                };

                dataContext.Add(newEmployee);
                dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Update(int id, EmployeeDTO obj)
        {
            try
            {
                var employee = Get(id);

                employee.FirstName = obj.Name ?? employee.FirstName;
                employee.LastName = obj.FamilyName ?? employee.LastName;
                employee.Title = obj.Tag ?? employee.Title;
                employee.Address = obj.Address ?? employee.Address;

                dataContext.Update(employee);
                dataContext.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un error al guardar los cambios");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var employee = Get(id);
                dataContext.Employees.Remove(employee);
                dataContext.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un error al interntar borrar el usuario.");
            }
        }

        public class Filter : FilterController<Employee>
        {
            public override IQueryable<Employee> FilterBy(FilterSpecification<Employee> filter)
            {
                return filter.Filter(new EmployeeSC().GetAll());
            }
        }

        public class FilterByCountry : FilterSpecification<Employee>
        {
            private string country;
            public FilterByCountry(string country)
            {
                this.country = country;
            }
            protected override IQueryable<Employee> ApplyFilter(IQueryable<Employee> list)
            {
                return list.Where(w => w.Country == country);
            }
        }
    }
}
