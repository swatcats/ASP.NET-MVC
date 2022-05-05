using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
        : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        //Database seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "School" },
            new Category { CategoryId = 2, Name = "Work" },
            new Category { CategoryId = 3, Name = "Family" }
            );
            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                ContactId = 1,
                FirstName = "Aaron",
                LastName = "Henry",
                Phone = "(502) 220-3637",
                Email = "ajhenr07@louisville.edu",
                CategoryId = 1,
                Organization = "",
                DateAdded = "2/22/2022"
            },
            new Contact
            {
                ContactId = 2,
                FirstName = "Lamar",
                LastName = "Clark",
                Phone = "(502) 324-3457",
                Email = "lgclar04@louisville.edu",
                CategoryId = 1,
                Organization = "",
                DateAdded = "2/22/2022"
            },
            new Contact
            {
                ContactId = 3,
                FirstName = "Linda",
                LastName = "Delgado",
                Phone = "(502) 242-2649",
                Email = "lkdelg09@louisville.edu",
                CategoryId = 1,
                Organization = "",
                DateAdded = "2/22/2022"
            }
            );
        }
    }
}