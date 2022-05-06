using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarterly_Sales.Models
{
    public class SaleListViewModel
    {
        public List<Sale> Sales { get; set; }
        public List<Employee> Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
