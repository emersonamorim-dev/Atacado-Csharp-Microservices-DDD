using MicroservicoCompras.Api.Config;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Application.Services;
using MicroservicoCompras.Domain.Interfaces;
using MicroservicoCompras.Infra.Data;
using MicroservicoCompras.Infra.Interfaces;
using MicroservicoCompras.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configurações do banco de dados
builder.Services.Configure<ClientesDatabaseSettings>(builder.Configuration.GetSection("ClientesDatabaseSettings"));
builder.Services.Configure<PagamentosDatabaseSettings>(builder.Configuration.GetSection("PagamentosDatabaseSettings"));
builder.Services.Configure<VendasDatabaseSettings>(builder.Configuration.GetSection("VendasDatabaseSettings"));
builder.Services.Configure<PedidosDatabaseSettings>(builder.Configuration.GetSection("PedidosDatabaseSettings"));

// Injeção de dependência para Repositórios e Serviços
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();

builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IPedidosService, PedidosService>();

builder.Services.AddScoped<IVendasRepository, VendasRepository>();
builder.Services.AddScoped<IVendasService, VendasService>();

// Configuração de Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroservicoCompras.Api API", Version = "v1" });

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
