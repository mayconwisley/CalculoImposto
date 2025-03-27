using CalculoImposto.Application;
using CalculoImposto.Infrastructure;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var passDatabase = Environment.GetEnvironmentVariable("SQLSenha", EnvironmentVariableTarget.Machine);
string connectionString = builder.Configuration.GetConnectionString("CalculoImposto")!.Replace("{{pass}}", passDatabase);

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString, b => b.MigrationsAssembly("CalculoImposto.Api"));
});


builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();
app.MapOpenApi();
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(opt =>
    {
        opt.Title = "Calculo Imposto API";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
