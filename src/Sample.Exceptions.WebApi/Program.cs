using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Exceptions.WebApi.Core.Extensions;
using Sample.Exceptions.WebApi.Core.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
SerilogExtensions.AddSerilogApi(builder.Configuration);
builder.Host.UseSerilog(Log.Logger);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerApi(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = LogEnricherExtensions.EnrichFromRequest);

app.UseMiddleware<RequestSerilLogMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwaggerDocApi();

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();