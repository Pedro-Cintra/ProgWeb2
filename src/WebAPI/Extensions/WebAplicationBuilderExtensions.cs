using Controllers;
using Controllers.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Net.Mime;
using WebAPI.Helpers;

namespace WebAPI.Extensions;

public static class WebAplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        IServiceCollection services = builder.Services;

        services.ConfigureCors();
        services.RegisterServices();
        services.ConfigureSqlContext(builder.Configuration);
        services.AddAutoMapper(typeof(Program));
        services.AddMemoryCache();
        services.ConfigureJWT(builder.Configuration);
        services.ConfigureOptions(builder.Configuration);
        services.ConfigureSwagger();
        services.AddHealthChecks();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddScoped<ValidationFilterAttribute>();
        services.AddControllers(options =>
        {
            options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
            options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));

            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;

            options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseParameterTransformer()));
        }).AddApplicationPart(typeof(AssemblyReference).Assembly)
          .AddJsonOptions(options => options.ConfigureJson());

        services.AddEndpointsApiExplorer();

        return builder;
    }
}
