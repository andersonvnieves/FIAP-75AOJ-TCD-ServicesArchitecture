using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace OrderService.Queue
{
    public class OrderMessagePublisher
    {
        private readonly ITopicClient _queueClient;

        public OrderMessagePublisher(ITopicClient queueClient)
        {
            _queueClient = queueClient;
        }

        public Task Publish(string messagePayload)
        {
            var message = new Message(Encoding.UTF8.GetBytes(messagePayload));
            return _queueClient.SendAsync(message);
        }
    }
}
