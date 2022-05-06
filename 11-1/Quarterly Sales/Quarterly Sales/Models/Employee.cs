using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quarterly_Sales.Models
{
    public class Employee
    {
        // PK
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a date of birth.")]
        public DateTime DOB { get; set; }
        [Range(typeof(DateTime), "1/1/1995", "12/31/9999", ErrorMessage = "Date of hire must not be before 1/1/1995.")]
        public DateTime DateOfHire { get; set; }
        public int ManagerId { get; set; }
    }
}
