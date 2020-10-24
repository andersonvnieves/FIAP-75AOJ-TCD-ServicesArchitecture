using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using OrderService.DTO;
using OrderService.Model;
using OrderService.Persistence.Repositories;
using OrderService.Queue;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderMessagePublisher _orderMessagePublisher;
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderMessagePublisher orderMessagePublisher, OrderRepository orderRepository)
        {
            _orderMessagePublisher = orderMessagePublisher;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get(Guid orderId)
        {
            return Ok(_orderRepository.GetById(orderId));
        }

        [HttpPost]
        public IActionResult Post(OrderDTO order)
        {
            _orderMessagePublisher.Publish(JsonSerializer.Serialize(order));
            return Ok();
        }

        [HttpGet]
        [Route("GetStatusByOrderId")]
        public IActionResult GetStatusByOrderId(Guid orderId)
        {
            return Ok();
        }
    }
}
