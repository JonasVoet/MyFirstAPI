using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
