using Microsoft.Extensions.Logging;
using Wolverine.Message;

namespace Wolverine.RabbitMQ.Consumer;

public sealed class MessageCreatedHandler(ILogger<MessageCreatedHandler> logger)
{
    public void Handle(MessageCreated message) =>
        logger.LogInformation("Message created is: {message}", message);
}
