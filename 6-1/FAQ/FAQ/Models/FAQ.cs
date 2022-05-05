using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FAQ.Models
{
    public class FAQ
    {
        // PK
        public int FAQId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        // Category FK
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        // Topic FK
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
