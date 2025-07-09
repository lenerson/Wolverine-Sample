using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;
using Wolverine.Message;
using Wolverine.RabbitMQ;
using Wolverine.RabbitMQ.Producer;

using var host = Host.CreateDefaultBuilder()
    .UseWolverine(options =>
    {
        const string exchangeName = "my-messages-exchange";

        options.UseRabbitMq(c =>
        {
            c.HostName = "localhost";
        })
        .DeclareExchange(
            exchangeName,
            exchange =>
            {
                exchange.BindQueue("my-message-queue", "exchangeToMyMessages");
            }
        )
        .AutoProvision();

        options.PublishMessage<MessageCreated>().ToRabbitExchange(exchangeName);

        options.Services.AddHostedService<ProducerBackgroundService>();
    }).Build();

await host.RunAsync();