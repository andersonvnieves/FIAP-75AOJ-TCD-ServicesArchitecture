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
    public class ShippingCompanyController : ControllerBase
    {
        private readonly ShippingCompanyRepository _shippingCompanyRepository;

        public ShippingCompanyController(ShippingCompanyRepository shippingCompanyRepository)
        {
            _shippingCompanyRepository = shippingCompanyRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShippingCompanyDTO sp)
        {
            var result = _shippingCompanyRepository.Insert(sp.ShippingCompanyName);
            return Created(result.ShippingCompanyId.ToString(),result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shippingCompanyRepository.List());
        }
    }
}
