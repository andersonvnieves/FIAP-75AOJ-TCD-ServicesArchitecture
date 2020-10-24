using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCostCalculator.DTO
{
    public class EstimateShippingCostDTO
    {
        public string ShipingCompanyName { get; set; }
        public DateTime ShippingIn { get; set; }
        public string Price { get; set; }
    }
}
