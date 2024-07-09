using Common.Logging;
using Microsoft.EntityFrameworkCore;
using Product.API.Extentions;
using Product.API.Persistence;
using Serilog;


var builder = WebApplication.CreateBuilder(args);



Log.Information("Start Product API up");
try
{
    builder.Host.UseSerilog(Serilogger.Configure);
    builder.Host.AddAppConfigurations();
    builder.Services.AddInfrastructure(builder.Configuration);




    builder.Host.UseSerilog((ctx, lc) =>

        lc.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext().ReadFrom.Configuration(ctx.Configuration)
    );
    

   
    var app = builder.Build();
    app.UseInfrastructure();
    // Configure the HTTP request pipeline.
    app.MigrateDatabase<ProductContext>((context, services) =>
    {
        ProductContextSeed.SeedProductAsync(context,Log.Logger).Wait();
    }).Run();
    
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }
    Log.Fatal(ex, "Unhandled exception");

}
finally
{
    Log.Information("Shut down Product API complete");
    Log.CloseAndFlush();
}


