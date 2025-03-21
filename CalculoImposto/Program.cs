using CalculoImposto.Application;
using CalculoImposto.Infrastructure;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Minha API",
        Description = "Uma API para demonstração",
    });
});

var passDatabase = Environment.GetEnvironmentVariable("SQLSenha", EnvironmentVariableTarget.Machine);
string connectionString = builder.Configuration.GetConnectionString("CalculoImposto")!.Replace("{{pass}}", passDatabase);

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString, b => b.MigrationsAssembly("CalculoImposto.Api"));
});


builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo Imposto"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
