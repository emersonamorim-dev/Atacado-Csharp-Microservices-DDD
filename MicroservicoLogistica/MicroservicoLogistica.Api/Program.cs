using MicroservicoLogistica.Application.Services;
using MicroservicoLogistica.Domain.Interfaces;
using MicroservicoLogistica.Infra.Data;
using MicroservicoLogistica.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Configura��es do banco de dados
// Adicionando as configura��es para as novas entidades
builder.Services.Configure<GestaoVeiculosDatabaseSettings>(builder.Configuration.GetSection(nameof(GestaoVeiculosDatabaseSettings)));
builder.Services.Configure<GestaoPedidosDatabaseSettings>(builder.Configuration.GetSection(nameof(GestaoPedidosDatabaseSettings)));
builder.Services.Configure<GestaoRotasDatabaseSettings>(builder.Configuration.GetSection(nameof(GestaoRotasDatabaseSettings)));
builder.Services.Configure<RastreamentoEntregasDatabaseSettings>(builder.Configuration.GetSection(nameof(RastreamentoEntregasDatabaseSettings)));



// Inje��o de depend�ncia para Reposit�rios e Servi�os
// Adicionando os novos reposit�rios e servi�os
builder.Services.AddScoped<IGestaoVeiculosRepository, GestaoVeiculosRepository>();
builder.Services.AddScoped<IGestaoVeiculosService, GestaoVeiculosService>();

builder.Services.AddScoped<IGestaoPedidosRepository, GestaoPedidosRepository>();
builder.Services.AddScoped<IGestaoPedidosService, GestaoPedidosService>();

builder.Services.AddScoped<IGestaoRotasRepository, GestaoRotasRepository>();
builder.Services.AddScoped<IGestaoRotasService, GestaoRotasService>();

builder.Services.AddScoped<IRastreamentoEntregasRepository, RastreamentoEntregasRepository>();
builder.Services.AddScoped<IRastreamentoEntregasService, RastreamentoEntregasService>();



// Configura��o de Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroservicoLogistica.Api API", Version = "v1" });

    // Adicione esta linha para tratar enums como strings no Swagger
    c.UseInlineDefinitionsForEnums();
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

// Configura��o do pipeline de solicita��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

