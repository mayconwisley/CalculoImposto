using CalculoImposto.API.Banco;
using CalculoImposto.API.Repositorio.INSS;
using CalculoImposto.API.Repositorio.INSS.Interface;
using CalculoImposto.API.Servico.INSS;
using CalculoImposto.API.Servico.INSS.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var passDatabase = Environment.GetEnvironmentVariable("SQLSenha", EnvironmentVariableTarget.Machine);
string strDatabase = builder.Configuration.GetConnectionString("CalculoImposto")!.Replace("{{pass}}", passDatabase);
builder.Services.AddDbContext<CalculoImpostoContext>(cd => cd.UseSqlServer(strDatabase));

builder.Services.AddScoped<IINSSRepositorio, INSSRepositorio>();
builder.Services.AddScoped<IINSSServico, INSSServico>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
