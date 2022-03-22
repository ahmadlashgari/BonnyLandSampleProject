using BL.Framework.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BL.Sample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMqController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PushNotification()
        {
            await _publishEndpoint.Publish(new SmsNotificationSentEvent
            {
                Message = "Test",
                To = "09123901915"
            });

            return Ok();
        }
    }
}
