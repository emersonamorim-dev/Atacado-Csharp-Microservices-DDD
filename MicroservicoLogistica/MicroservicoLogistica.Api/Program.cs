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

// Configurações do banco de dados
// Adicionando as configurações para as novas entidades
builder.Services.Configure<GestaoVeiculosDatabaseSettings>(builder.Configuration.GetSection(nameof(GestaoVeiculosDatabaseSettings)));
builder.Services.Configure<GestaoPedidosDatabaseSettings>(builder.Configuration.GetSection(nameof(GestaoPedidosDatabaseSettings)));
builder.Services.Configure<GestaoRotasDatabaseSettings>(builder.Configuration.GetSection(nameof(GestaoRotasDatabaseSettings)));
builder.Services.Configure<RastreamentoEntregasDatabaseSettings>(builder.Configuration.GetSection(nameof(RastreamentoEntregasDatabaseSettings)));



// Injeção de dependência para Repositórios e Serviços
// Adicionando os novos repositórios e serviços
builder.Services.AddScoped<IGestaoVeiculosRepository, GestaoVeiculosRepository>();
builder.Services.AddScoped<IGestaoVeiculosService, GestaoVeiculosService>();

builder.Services.AddScoped<IGestaoPedidosRepository, GestaoPedidosRepository>();
builder.Services.AddScoped<IGestaoPedidosService, GestaoPedidosService>();

builder.Services.AddScoped<IGestaoRotasRepository, GestaoRotasRepository>();
builder.Services.AddScoped<IGestaoRotasService, GestaoRotasService>();

builder.Services.AddScoped<IRastreamentoEntregasRepository, RastreamentoEntregasRepository>();
builder.Services.AddScoped<IRastreamentoEntregasService, RastreamentoEntregasService>();



// Configuração de Controllers e Swagger
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

// Configuração do pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

