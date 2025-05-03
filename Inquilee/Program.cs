using Inquilee.Configurations;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "API is running.");

app.ConfigureMiddlewares(app.Environment);

app.UseHttpsRedirection();

app.Run();