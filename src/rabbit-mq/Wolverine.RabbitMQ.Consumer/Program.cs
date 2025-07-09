using Microsoft.Extensions.Hosting;
using Wolverine;
using Wolverine.RabbitMQ;

using var host = Host.CreateDefaultBuilder()
    .UseWolverine(options =>
    {
        options.UseRabbitMq(c =>
        {
            c.HostName = "localhost";
        }).AutoProvision();

        options.ListenToRabbitQueue("my-message-queue");
    }).Build();

await host.RunAsync();