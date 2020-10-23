using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using OrderService.Model;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {
            
        }

        [HttpGet]
        public IActionResult Get(Guid orderId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(OrderDTO order)
        {
            
            return Created("", new Order());
        }

        [HttpGet]
        [Route("GetStatusByOrderId")]
        public IActionResult GetStatusByOrderId(Guid orderId)
        {
            return Ok();
        }
    }
}
