using KhWebApi.WebApi.Database;
using KhWebApi.WebApi.Models;
using KhWebApi.WebApi.Repositories.Implementations;
using KhWebApi.WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var WebPortalOriginPolicy = "khwebportal";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ModelContext>(opt =>
{
    opt.UseInMemoryDatabase("ShoppingWebApi");
    opt.EnableSensitiveDataLogging(true);
});
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingWebApi", Version = "v1" });
});

builder.Services.AddCors(options =>
    options.AddPolicy(name: WebPortalOriginPolicy,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      }));
var app = builder.Build();

using (var context = app.Services.CreateAsyncScope())
{
    await DbDataInitializer.SeedDataAsync(context.ServiceProvider.GetRequiredService<ModelContext>());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingWebApi v1"));
}

app.UseHttpsRedirection();

app.UseCors(WebPortalOriginPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
