using AssetManager.Api.Middleware;
using AssetManager.Application.Handlers.Assets.Queries.GetAssetList;
using AssetManager.Infrastructure.Configuration;
using AssetManager.Infrastructure.Database;
using Contracts.Database;
using FluentValidation;
using MediatR;
using Serilog;
using System.Text.Json;

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri(EnvUtil.GetElasticUrl())) { 
    AutoRegisterTemplate = true,
    IndexFormat = "asset-manager"
}).CreateLogger();

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSerilog();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();

services.AddAutoMapper(typeof(GetAssetListModel));
services.AddDbContext<IAssetManagerContext, AssetManagerContext>();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAssetListModel).Assembly));

services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower;
});

services.AddValidatorsFromAssemblyContaining<GetAssetListModel>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

services.AddExceptionHandler<ExceptionActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSerilogRequestLogging();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

// This is used in the tests
public partial class Program { }