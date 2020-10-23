using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ProductService.Model
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
