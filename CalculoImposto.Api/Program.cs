using CalculoImposto.Application;
using CalculoImposto.Infrastructure;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});
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
        opt.WithTitle("Calculo Imposto API")
            .WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Axios);
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
