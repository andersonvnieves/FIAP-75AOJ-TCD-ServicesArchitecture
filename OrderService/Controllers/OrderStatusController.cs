using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderService.Persistence.Repositories;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly OrderStatusRepository _orderStatusRepository;

        public OrderStatusController(OrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderStatusRepository.List());
        }

        [HttpPost]
        public IActionResult Post(string status)
        {
            var result = _orderStatusRepository.Insert(status);
            return Created(result.OrderStatusId.ToString(), result);
        }
    }
}
