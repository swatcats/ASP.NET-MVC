using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quarterly_Sales.Models
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options)
        : base(options)
        { }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //Database seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Ada",
                LastName = "Lovelace",
                DOB = new DateTime(1956, 12, 10),
                DateOfHire = new DateTime(1995, 1, 1),
                ManagerId = 2
            },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Aaron",
                LastName = "Henry",
                DOB = new DateTime(2000, 12, 31),
                DateOfHire = new DateTime(2022, 1, 1),
                ManagerId = 0
            }
            );
            modelBuilder.Entity<Sale>().HasData(
            new Sale
            {
                SaleId = 1,
                Quarter = 1,
                Year = 2022,
                Amount = 100000,
                EmployeeId = 1
            },
            new Sale
            {
                SaleId = 2,
                Quarter = 2,
                Year = 2022,
                Amount = 75000,
                EmployeeId = 1
            },
            new Sale
            {
                SaleId = 3,
                Quarter = 2,
                Year = 2022,
                Amount = 1000000000,
                EmployeeId = 2
            }
            );
        }
    }
}
