using BL.Framework.Events;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BL.Sample.ApplicationServices.Entity.Consumers
{
    public class EntityConsumer : IConsumer<SmsNotificationSentEvent>
    {
        private readonly ILogger<EntityConsumer> _logger;

        public EntityConsumer(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetService<ILogger<EntityConsumer>>();
        }

        public Task Consume(ConsumeContext<SmsNotificationSentEvent> context)
        {
            _logger.LogInformation("Message Consumed");

            return Task.CompletedTask;
        }
    }
}
