using CSS.CctxClient;
using CSS.Impl;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

services.AddOpenApi();
services.AddServices();
services.AddCctxClients();
services.AddControllers();

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
