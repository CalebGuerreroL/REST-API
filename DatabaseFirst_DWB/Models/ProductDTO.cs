using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Models
{
    public  class ProductDTO
    {
        public string Product { get; set; }
        public decimal? Price { get; set; }
        public string QuantityPerProduct { get; set; }
        public short? InStock { get; set; }
    }
}
