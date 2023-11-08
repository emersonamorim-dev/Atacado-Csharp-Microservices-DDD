using MicroservicoMarketing.Application.Service;
using MicroservicoMarketing.Domain.Interfaces;
using MicroservicoMarketing.Infra.Data;
using MicroservicoMarketing.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Configurações do banco de dados
// Adicionando as configurações para as novas entidades
builder.Services.Configure<SegmentacaoClientesDatabaseSettings>(builder.Configuration.GetSection(nameof(SegmentacaoClientesDatabaseSettings)));

// Injeção de dependência para Repositórios e Serviços
// Adicionando os novos repositórios e serviços
builder.Services.AddScoped<ISegmentacaoClientesRepository, SegmentacaoClientesRepository>();
builder.Services.AddScoped<ISegmentacaoClientesService, SegmentacaoClientesService>();



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

