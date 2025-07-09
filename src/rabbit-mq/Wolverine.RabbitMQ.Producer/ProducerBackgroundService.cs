using JasperFx.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wolverine.Message;

namespace Wolverine.RabbitMQ.Producer;

public sealed class ProducerBackgroundService(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();

        var bus = scope.ServiceProvider.GetRequiredService<IMessageBus>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<ProducerBackgroundService>>();
        var count = 0;

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var message = new MessageCreated(Guid.NewGuid(), $"Content {count++}", DateTime.Now);

                logger.LogInformation("Produced message is: {message}", message);

                await bus.SendAsync(message);
                await Task.Delay(30.Seconds(), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
