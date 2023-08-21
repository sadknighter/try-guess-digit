// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TryGuessDigitConsole.Interfaces;
using TryGuessDigitConsole.Services;

IConfigurationBuilder builder = new ConfigurationBuilder();
AppSettingsBuilder.BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger.Information("Application Starting");

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<IConsoleUiService, ConsoleUiService>();
        services.AddTransient<IDigitGenerator, DigitGenerator>();
        services.AddTransient<IGuessValidator, GuessValidator>();
    })
    .UseSerilog()
    .Build();

var svc = ActivatorUtilities.CreateInstance<ConsoleUiService>(host.Services);
svc.Run();