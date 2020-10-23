using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Model
{
    public class OrderStatus
    {
        public Guid OrderStatusId { get; set; }
        public string StatusName { get; set; }
    }
}
