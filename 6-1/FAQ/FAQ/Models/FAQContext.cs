using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Models
{
    public class FAQContext : DbContext
    {
        public FAQContext(DbContextOptions<FAQContext> options)
        : base(options)
        { }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        //Database seed data
        protected override void OnModelCreating(
        ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { CategoryId = "general", Name = "General" },
               new Category { CategoryId = "history", Name = "History" }
           );
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "bootstrap", Name = "Bootstrap" },
                new Topic { TopicId = "c#", Name = "C#" },
                new Topic { TopicId = "javascript", Name = "JavaScript" }
            );
            modelBuilder.Entity<FAQ>().HasData(
            new FAQ
            {
                FAQId = 1,
                Question = "What is Bootstrap?",
                Answer = "A CSS framework for creating responsive web apps for multiple screen sizes.",
                CategoryId = "general",
                TopicId = "bootstrap"
            },
            new FAQ
            {
                FAQId = 2,
                Question = "What is C#?",
                Answer = "A general purpose object oriented language that uses a concise, Java-like syntax.",
                CategoryId = "general",
                TopicId = "c#"
            },
            new FAQ
            {
                FAQId = 3,
                Question = "What is JavaScript?",
                Answer = "A general purpose scripting language that executes in a web browser.",
                CategoryId = "general",
                TopicId = "javascript"
            },
            new FAQ
            {
                FAQId = 4,
                Question = "When was Bootstrap first released?",
                Answer = "In 2011.",
                CategoryId = "history",
                TopicId = "bootstrap"
            },
            new FAQ
            {
                FAQId = 5,
                Question = "When was C# first released?",
                Answer = "In 2002.",
                CategoryId = "history",
                TopicId = "c#"
            },
            new FAQ
            {
                FAQId = 6,
                Question = "When was JavaScript first released?",
                Answer = "In 1995.",
                CategoryId = "history",
                TopicId = "javascript"
            }
            );
        }
    }
}