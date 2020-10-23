using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShippingCostCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {

        public ShippingController()
        {
                
        }

        [HttpGet]
        [Route("GetEstimateShippingCost")]
        public IActionResult Get()
        {
            return Ok("Free Shipping");
        }
    }
}
