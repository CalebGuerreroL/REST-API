using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Models
{
    public class CustomerDTO
    {
        public string Identifier { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
    }
}
