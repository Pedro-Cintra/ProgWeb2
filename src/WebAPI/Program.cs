using NLog;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile($"{Directory.GetCurrentDirectory()}/nlog.config");

builder.ConfigureServices();

var app = builder.Build();

app.ConfigureApp();

await app.RunAsync();
