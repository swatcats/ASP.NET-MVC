using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        // Contact PK
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter an email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select a category.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        // Category FK
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string Organization { get; set; }

        // DateAdded backing field
        private string _dateAdded;
        //DateAdded readonly
        public string DateAdded
        {
            get
            {
                return _dateAdded;
            }
            set
            {
                if (_dateAdded == null)
                {
                    _dateAdded = value;
                }
            }
        }
        // User slug
        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.ToString();
}
}
