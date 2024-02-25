using Amazon.SQS;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageConsumer : ControllerBase
{
    private readonly IAmazonSQS _sqsClient;

    public MessageConsumer(IAmazonSQS sqsClient)
    {
        _sqsClient = sqsClient;
    }

    [HttpPost]
    public async Task<IActionResult> CreateQueue([FromQuery] string queueName) =>
        Created("/", await _sqsClient.CreateQueueAsync(queueName));

    [HttpGet]
    public async Task<IActionResult> GetQueues()
    {
        var createdqQueue = await _sqsClient.
        
        var responseList = await _sqsClient.ListQueuesAsync("");
        return Ok(responseList.QueueUrls);
    }
}