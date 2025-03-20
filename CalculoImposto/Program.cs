using CalculoImposto.Application;
using CalculoImposto.Infrastructure;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo Imposto v1");
    c.RoutePrefix = string.Empty;
});
app.UseAuthorization();

app.MapControllers();

app.Run();
