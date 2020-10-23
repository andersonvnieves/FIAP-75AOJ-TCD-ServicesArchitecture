using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Model
{
    public class ShippingAddress
    {
        public Guid ShippingAddressId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Estate { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
