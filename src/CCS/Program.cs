using CCS.CctxClient;
using CCS.Core.Options;
using CCS.Excel;
using CCS.Impl;
using CCS.Infr;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

services.Configure<CcsOptions>(builder.Configuration);

services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, ct) =>
    {
        document.Info.Title = "CryptoCurrency Service";
        document.Info.Description = "Analysis and processing of OHLCV and other data from trading exchanges";
        return Task.CompletedTask;
    });
});
services.AddServices();
services.AddCctxClients();
services.AddInfrastructure();
services.AddControllers();
services.AddExcelExports();

WebApplication app = builder.Build();

app.MapDefaultControllerRoute();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.MapScalarApiReference(options => options.Theme = ScalarTheme.Alternate);
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
