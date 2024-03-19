using CalculoImposto.API.Banco;
using CalculoImposto.API.Repositorio.INSS;
using CalculoImposto.API.Repositorio.INSS.Interface;
using CalculoImposto.API.Repositorio.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.Calculo;
using CalculoImposto.API.Servico.Calculo.Interface;
using CalculoImposto.API.Servico.INSS;
using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.API.Servico.IRRF;
using CalculoImposto.API.Servico.IRRF.Interface;
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
builder.Services.AddScoped<IIRRFRepositorio, IRRFRepositorio>();
builder.Services.AddScoped<IIRRFServico, IRRFServico>();
builder.Services.AddScoped<IDependenteRepositorio, DependenteRepositorio>();
builder.Services.AddScoped<IDependenteServico, DependenteServico>();
builder.Services.AddScoped<IDescontoMinimoRespositorio, DescontoMinimoRepositorio>();
builder.Services.AddScoped<IDescontoMinimoServico, DescontoMinimoServico>();
builder.Services.AddScoped<ISimplificadoRepositorio, SimplificadoRepositorio>();
builder.Services.AddScoped<ISimplificadoServico, SimplificadoServico>();
builder.Services.AddScoped<ICalculoImpostoServico, CalculoImpostoServico>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo Imposto v1"));
app.UseAuthorization();

app.MapControllers();

app.Run();
