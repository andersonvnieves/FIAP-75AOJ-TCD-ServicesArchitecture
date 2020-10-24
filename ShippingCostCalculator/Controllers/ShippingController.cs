using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingCostCalculator.DTO;
using ShippingCostCalculator.Persistence.Repositories;

namespace ShippingCostCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly ShippingCompanyRepository _shippingCompanyRepository;

        public ShippingController(ShippingCompanyRepository shippingCompanyRepository)
        {
            _shippingCompanyRepository = shippingCompanyRepository;
        }

        [HttpPost]
        [Route("GetEstimateShippingCost")]
        public IActionResult Post([FromBody] DeliveryInformationDTO delivery)
        {
            var rnd = new Random();
            var result = new List<EstimateShippingCostDTO>();

            foreach (var shippingCompany in _shippingCompanyRepository.List())
            {
             result.Add(new EstimateShippingCostDTO()
             {
                 ShipingCompanyName = shippingCompany.ShippingCompanyName,
                 ShippingIn = DateTime.Now.AddDays(rnd.Next(1,6)),
                 Price = $"R${rnd.Next(6,60)},{rnd.Next(0,99)}"
             });   
            }

            return Ok(result);
        }
    }
}
