using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using CleanArchitectrure.Application.UseCases;
using CleanArchitectrure.Persistence;
using AzureFunctionCQRS.Extensions.Middleware;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

//Add methods Extensions
builder.Services.AddInjectionPersistence();
builder.Services.AddInjectionApplication();
MiddlewareExtension.AddMiddleware(builder);

builder.Build().Run();

