using CCS.CctxClient;
using CCS.Core.Options;
using CCS.Impl;
using CCS.Infr;
using Scalar.AspNetCore;
using CCS.Excel;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

services.Configure<CcsOptions>(builder.Configuration);

services.AddOpenApi();
services.AddServices();
services.AddCctxClients();
services.AddInfrastructure();
services.AddControllers();
services.AddExcelExports();

WebApplication app = builder.Build();

app.MapDefaultControllerRoute();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
