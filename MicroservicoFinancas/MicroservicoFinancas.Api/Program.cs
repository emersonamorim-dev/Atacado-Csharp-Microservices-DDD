using MicroservicoFinancas.Domain.Interfaces;
using MicroservicoFinancas.Api.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text.Json.Serialization;
using MicroservicoFinancas.Infra.Repositories;
using MicroservicoFinancas.Infra.Data;
using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurações do banco de dados
// Adicionando as configurações para as novas entidades
builder.Services.Configure<OrcamentoDatabaseSettings>(builder.Configuration.GetSection(nameof(OrcamentoDatabaseSettings)));
builder.Services.Configure<AnaliseFinanceiraDatabaseSettings>(builder.Configuration.GetSection(nameof(AnaliseFinanceiraDatabaseSettings)));
builder.Services.Configure<PlanejamentoFinanceiroDatabaseSettings>(builder.Configuration.GetSection(nameof(PlanejamentoFinanceiroDatabaseSettings)));
builder.Services.Configure<AutomacaoProcessosDatabaseSettings>(builder.Configuration.GetSection(nameof(AutomacaoProcessosDatabaseSettings)));
builder.Services.Configure<ProcessamentoPagamentosDatabaseSettings>(builder.Configuration.GetSection(nameof(ProcessamentoPagamentosDatabaseSettings)));
builder.Services.Configure<RiscosDatabaseSettings>(builder.Configuration.GetSection(nameof(RiscosDatabaseSettings)));



// Injeção de dependência para Repositórios e Serviços
// Adicionando os novos repositórios e serviços
builder.Services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();

builder.Services.AddScoped<IAnaliseFinanceiraRepository, AnaliseFinanceiraRepository>();
builder.Services.AddScoped<IAnaliseFinanceiraService, AnaliseFinanceiraService>();

builder.Services.AddScoped<IPlanejamentoFinanceiroRepository, PlanejamentoFinanceiroRepository>();
builder.Services.AddScoped<IPlanejamentoFinanceiroService, PlanejamentoFinanceiroService>();

builder.Services.AddScoped<IAutomacaoProcessosRepository, AutomacaoProcessosRepository>();
builder.Services.AddScoped<IAutomacaoProcessosService, AutomacaoProcessosService>();

builder.Services.AddScoped< IProcessamentoPagamentosRepository, ProcessamentoPagamentosRepository>();
builder.Services.AddScoped< IProcessamentoPagamentosService, ProcessamentoPagamentosService>();

builder.Services.AddScoped<IRiscosRepository, RiscosRepository>();
builder.Services.AddScoped<IRiscosService, RiscosService>();


// Configuração de Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroservicoFinancas.Api API", Version = "v1" });

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

