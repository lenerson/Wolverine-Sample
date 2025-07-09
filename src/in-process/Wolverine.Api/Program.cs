using Scalar.AspNetCore;
using Wolverine;
using Wolverine.Message;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWolverine();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapPost("/message", async (CreateMessage request, IMessageBus messageBus) =>
{
    await messageBus.SendAsync(request);
}).WithName("CreateMessage");

app.Run();