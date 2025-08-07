using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebAPI.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApp(this WebApplication app)
    {
        var logger = app.Services.GetRequiredService<ILoggerManager>();
        app.ConfigureExceptionHandler(logger);

        if (app.Environment.IsProduction())
            app.UseHsts();

        app.UseStaticFiles();
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseCors("CorsPolicy");
        app.UsePathBase("/api");
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/progwebapi/swagger.json", "progweb API");
            c.RoutePrefix = "swagger";

            c.DocExpansion(DocExpansion.None);
            c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false); //para reduzir travamentos do swagger ao processar responses muito pesadas
            c.ConfigObject.DefaultModelsExpandDepth = -1;
            c.ConfigObject.PersistAuthorization = true;
            c.ConfigObject.DisplayRequestDuration = true;
        });

        app.UseHealthChecks("/healthcheck");

        return app;
    }
}
