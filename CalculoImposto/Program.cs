using CalculoImposto.API.Banco;
using CalculoImposto.API.CRUD;
using CalculoImposto.API.CRUD.Interface;
using CalculoImposto.API.Model.INSS;
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
using CalculoImposto.Modelo.DTO.INSS;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

builder.Services.AddScoped(typeof(ICrudBase<>), typeof(CrudBase<>));

builder.Services.AddScoped<IInssRepositorio, InssRepositorio>();
builder.Services.AddScoped<IInssServico, InssServico>();
builder.Services.AddScoped<IIrrfRepositorio, IrrfRepositorio>();
builder.Services.AddScoped<IIrrfServico, IrrfServico>();
builder.Services.AddScoped<IDependenteRepositorio, DependenteRepositorio>();
builder.Services.AddScoped<IDependenteServico, DependenteServico>();
builder.Services.AddScoped<IDescontoMinimoRespositorio, DescontoMinimoRepositorio>();
builder.Services.AddScoped<IDescontoMinimoServico, DescontoMinimoServico>();
builder.Services.AddScoped<ISimplificadoRepositorio, SimplificadoRepositorio>();
builder.Services.AddScoped<ISimplificadoServico, SimplificadoServico>();
builder.Services.AddScoped<ICalculoImpostoServico, CalculoImpostoServico>();
builder.Services.AddScoped<ICalculoBaseEstabilidadeServico, CalculoBaseEstabilidadeServico>();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo Imposto v1"));
app.UseAuthorization();

app.MapControllers();

app.Run();
