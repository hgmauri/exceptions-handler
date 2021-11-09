using System;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;

namespace Sample.Exceptions.WebApi.Core.Extensions;

public static class SerilogExtensions
{
    public static void AddSerilogApi(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.WithProperty("ApplicationName", $"API Exceptions - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
            .CreateLogger();
    }
}
