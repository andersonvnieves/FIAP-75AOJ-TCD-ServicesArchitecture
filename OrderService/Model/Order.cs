using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public Guid ShippingAddressId { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
    }
}
