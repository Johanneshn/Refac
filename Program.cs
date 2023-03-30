using WebApplication3;
using WebApplication3.Infrastructure;
using WebApplication3.Interfaces;
using WebApplication3.Proto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEventBusPublisher, NatsPublisher>();
builder.Services.AddSingleton<ICursorService, NatsCursorService>();

builder.Services.AddSingleton<ICacheService<Position>, PositionCache>();
builder.Services.AddSingleton<ICacheService<Provision>, DeviceCache>();

builder.Services.AddSingleton<IEventCreator<Position>, PositionEventCreator>();
builder.Services.AddSingleton<IEventCreator<Provision>, DeviceEventCreator>();

builder.Services.AddSingleton<ICertReader<Position>, PositionReader>();
builder.Services.AddSingleton<ICertReader<Provision>, DeviceReader>();

builder.Services.AddSingleton(typeof(IEventBaseService<>), typeof(EventBaseService<>));

builder.Services.AddHostedService<DeviceWorker>();
builder.Services.AddHostedService<PositionWorker>();

var app = builder.Build();

app.Run();