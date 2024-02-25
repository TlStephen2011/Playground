using Amazon.SimpleNotificationService;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers;

[ApiController]
[Route("[controller]")]
public class MessagePublisher : ControllerBase
{
    private readonly IAmazonSimpleNotificationService _snsClient;

    public MessagePublisher(IAmazonSimpleNotificationService snsClient)
    {
        _snsClient = snsClient;
    }

    [HttpPost]
    [Route("/message")]
    public async Task<IActionResult> SendMessage([FromBody] CustomerDto customer, [FromQuery] string topic)
    {
        await _snsClient.PublishAsync(topic, customer.ToString());
        return Created("/", customer);
    }
}

public record CustomerDto(Guid Id, string FirstName, string LastName);