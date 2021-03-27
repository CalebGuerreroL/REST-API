using System;
using System.Linq;
using DatabaseFirst_DWB.DataAccess;
using DatabaseFirst_DWB.Models;
using DatabaseFirst_DWB.Services;

namespace DatabaseFirst_DWB
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerSC SC = new();

            CustomerDTO newCustomer = new()
            {
                Identifier = "MAPRX",
                Company = "MachineProxy",
                Contact = "Sebastian Loredo",
                Title = "Mr.",
                PhoneNumber = "8102469581"
            };

            SC.Add(newCustomer);
        }
    }
}
