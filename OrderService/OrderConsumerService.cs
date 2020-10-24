using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OrderService.DTO;
using OrderService.Model;
using OrderService.Persistence.Repositories;

namespace OrderService
{
    public class OrderConsumerService: BackgroundService
    {
        private readonly ISubscriptionClient _subscriptionClient;
        private readonly ShippingAddressRepository _shippingAddressRepository;
        private readonly OrderItemsRepository _orderItemsRepository;
        private readonly OrderRepository _orderRepository;

        public OrderConsumerService(ISubscriptionClient subscriptionClient, ShippingAddressRepository shippingAddressRepository, OrderItemsRepository orderItemsRepository, OrderRepository orderRepository)
        {
            _subscriptionClient = subscriptionClient;
            _shippingAddressRepository = shippingAddressRepository;
            _orderItemsRepository = orderItemsRepository;
            _orderRepository = orderRepository;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriptionClient.RegisterMessageHandler((message,token) =>
            {
                var orderDto = JsonConvert.DeserializeObject<OrderDTO>(Encoding.UTF8.GetString(message.Body));

                var shippingAddress = _shippingAddressRepository.Insert(new ShippingAddress()
                {
                    Street = orderDto.ShippingStreet,
                    ZipCode = orderDto.ShippingZipCode,
                    Estate = orderDto.ShippingEstate,
                    City = orderDto.ShippingCity,
                    Description = orderDto.ShippingDescription
                });

                var order = _orderRepository.Insert(new Order()
                {
                    UserId = orderDto.UserId,
                    OrderStatusId = orderDto.OrderStatusId,
                    TimeStamp = DateTime.Now,
                    ShippingAddressId = shippingAddress.ShippingAddressId
                });

                foreach (var item in orderDto.OrderItems)
                {
                    var orderItems = _orderItemsRepository.Insert(new OrderItems()
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                }
                


                return _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            }, new MessageHandlerOptions(args => Task.CompletedTask)
            {
                AutoComplete = false,
                MaxConcurrentCalls = 1
            });

            return Task.CompletedTask;
        }
    }
}
