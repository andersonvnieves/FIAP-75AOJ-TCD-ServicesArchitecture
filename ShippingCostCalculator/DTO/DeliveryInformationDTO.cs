using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCostCalculator.DTO
{
    public class DeliveryInformationDTO
    {
        public string ZipCodeOrigin { get; set; }
        public string ZipCodeDestination { get; set; }
    }
}
