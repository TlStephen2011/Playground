using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers;

[ApiController]
[Route("[controller]")]
public class AwsSnsController : ControllerBase
{
    private readonly IAmazonSimpleNotificationService _snsClient;

    public AwsSnsController(IAmazonSimpleNotificationService snsClient)
    {
        _snsClient = snsClient;
    }

    [HttpPost]
    [Route("/topic")]
    public async Task<IActionResult> SnsTopic([FromQuery] string topicName)
    {
        var topic = await _snsClient.CreateTopicAsync(topicName);
        return Created($"/awssns/snstopic/{topic.TopicArn}", topic.TopicArn);
    }

    [HttpGet]
    [Route("/topics")]
    public async Task<IActionResult> SnsTopics() => Ok((await _snsClient.ListTopicsAsync()).Topics);

    [HttpGet]
    [Route("/topic")]
    public async Task<IActionResult> SnsTopicByName([FromQuery] string topicName) =>
        Ok(await _snsClient.FindTopicAsync(topicName));

}
