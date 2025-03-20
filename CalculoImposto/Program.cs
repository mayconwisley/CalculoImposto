using CalculoImposto.Application;
using CalculoImposto.Infrastructure;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var passDatabase = Environment.GetEnvironmentVariable("SQLSenha", EnvironmentVariableTarget.Machine);
string connectionString = builder.Configuration.GetConnectionString("CalculoImposto")!.Replace("{{pass}}", passDatabase);

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString, b => b.MigrationsAssembly("CalculoImposto.Api"));
});


builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
