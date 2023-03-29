using WebApplication3;
using WebApplication3.Infrastructure;
using WebApplication3.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEventBusPublisher, NatsPublisher>();
builder.Services.AddSingleton<ICursorService, NatsCursorService>();

builder.Services.AddSingleton<EventCreatorServiceFactory, EventCreatorServiceFactory>();

builder.Services.AddHostedService<DeviceWorker>();

var app = builder.Build();

app.Run();