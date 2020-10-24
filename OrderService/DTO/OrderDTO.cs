using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.DTO
{
    public class OrderDTO
    {
        public Guid UserId { get; set; }


        public Guid OrderStatusId { get; set; }

        public ICollection<OrderItemsDTO> OrderItems { get; set; }

        public string ShippingStreet { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingEstate { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingDescription { get; set; }
    }
}
