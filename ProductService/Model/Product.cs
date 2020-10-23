using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductService.Model
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<KeyWord> KeyWords { get; set; }
    }
}
