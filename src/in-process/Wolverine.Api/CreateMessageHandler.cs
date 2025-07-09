using Wolverine.Message;

namespace Wolverine.Api;

public sealed class CreateMessageHandler(ILogger<CreateMessageHandler> logger)
{
    public void Handle(CreateMessage message) =>
        logger.LogInformation("Message is: {message}", message);
}
