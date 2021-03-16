using DatabaseFirst_DWB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Services
{
    public class BaseSC
    {
        protected NorthwindContext dataContext = new();
    }
}
