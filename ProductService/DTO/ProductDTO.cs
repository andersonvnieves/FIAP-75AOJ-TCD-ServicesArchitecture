
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public ICollection<string> KeyWords { get; set; }
    }
}
