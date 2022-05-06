using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quarterly_Sales.Models
{
    public class Sale
    {
        // Sale PK
        public int SaleId { get; set; }
        [Range(1, 4, ErrorMessage = "Please enter a quarter, 1-4.")]
        public int Quarter { get; set; }
        [Range(2001, 999999, ErrorMessage = "Please enter a year after 2000.")]
        public int Year { get; set; }
        [Range(0.01, 9999999999999999, ErrorMessage = "Please enter an ammount.")]
        public double Amount { get; set; }
        // Employee FK
        [Required(ErrorMessage = "Please select an employee.")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
