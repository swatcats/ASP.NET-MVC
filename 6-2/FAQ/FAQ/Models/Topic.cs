using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FAQ.Models
{
    public class Topic
    {
        // PK
        public string TopicId { get; set; }
        public string Name { get; set; }
    }
}
