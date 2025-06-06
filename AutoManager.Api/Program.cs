using AutoManager.Api.Data;
using AutoManager.Api.Endpoints;
using AutoManager.Api.Services;
using AutoManager.Core;
using AutoManager.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IVehicleService, VehicleService>();

builder.Services.AddOpenApi();

var MyAllowSpecificOrigins = "automanager";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "AutoManager API V1");
    });
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);
app.MapEndpoints();

app.Run();
