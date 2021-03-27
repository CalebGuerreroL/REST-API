using DatabaseFirst_DWB.DataAccess;
using DatabaseFirst_DWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Services
{
    public class CustomerSC : BaseSC, IActions<Customer, CustomerDTO, string>
    {
        public void Add(CustomerDTO obj)
        {
            try
            {
                var newCustomer = new Customer()
                {
                    CustomerId = obj.Identifier,
                    CompanyName = obj.Company,
                    ContactName = obj.Contact,
                    ContactTitle = obj.Title,
                    Phone = obj.PhoneNumber
                };

                dataContext.Add(newCustomer);
                dataContext.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un error tratando de agregar al cliente");
            }
        }

        public void Delete(string id)
        {
            try
            {
                var customer = Get(id);
                dataContext.Customers.Remove(customer);
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

        public Customer Get(string id)
        {
            var customer = GetAll().FirstOrDefault(fd => fd.CustomerId == id);

            if (customer == null)
                throw new ArgumentException($"El producto con el id: {id} no fue encontrado");

            return customer;
        }

        public IQueryable<Customer> GetAll()
        {
            return dataContext.Customers;
        }

        public void Update(string id, CustomerDTO obj)
        {
            try
            {
                var customer = Get(id);

                customer.CustomerId = obj.Identifier ?? customer.CustomerId;
                customer.CompanyName = obj.Company ?? customer.CompanyName;
                customer.ContactName = obj.Contact ?? customer.ContactName;
                customer.ContactTitle = obj.Title ?? customer.ContactTitle;
                customer.Phone = obj.PhoneNumber ?? customer.Phone;

                dataContext.Update(customer);
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
    }
}
