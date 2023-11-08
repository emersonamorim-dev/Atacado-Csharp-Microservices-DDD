using MicroservicoEstoque.Api.Config;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Application.Services;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using MicroservicoEstoque.Infra.Repositories;
using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configurações do banco de dados
// Adicionando as configurações para as novas entidades
builder.Services.Configure<ArmazemDatabaseSettings>(builder.Configuration.GetSection(nameof(ArmazemDatabaseSettings)));
builder.Services.Configure<ControleQualidadeDatabaseSettings>(builder.Configuration.GetSection(nameof(ControleQualidadeDatabaseSettings)));
builder.Services.Configure<DevolucaoDatabaseSettings>(builder.Configuration.GetSection(nameof(DevolucaoDatabaseSettings)));
builder.Services.Configure<FornecedorDatabaseSettings>(builder.Configuration.GetSection(nameof(FornecedorDatabaseSettings)));
builder.Services.Configure<IntegracaoSistemaDatabaseSettings>(builder.Configuration.GetSection(nameof(IntegracaoSistemaDatabaseSettings)));
builder.Services.Configure<InventarioDatabaseSettings>(builder.Configuration.GetSection(nameof(InventarioDatabaseSettings)));
builder.Services.Configure<PedidoCompraDatabaseSettings>(builder.Configuration.GetSection(nameof(PedidoCompraDatabaseSettings)));
builder.Services.Configure<PrevisaoDemandaDatabaseSettings>(builder.Configuration.GetSection(nameof(PrevisaoDemandaDatabaseSettings)));
builder.Services.Configure<RelatorioDatabaseSettings>(builder.Configuration.GetSection(nameof(RelatorioDatabaseSettings)));
builder.Services.Configure<SegurancaConformidadeDatabaseSettings>(builder.Configuration.GetSection(nameof(SegurancaConformidadeDatabaseSettings)));

// Injeção de dependência para Repositórios e Serviços
// Adicionando os novos repositórios e serviços
builder.Services.AddScoped<IArmazemRepository, ArmazemRepository>();
builder.Services.AddScoped<IArmazemService, ArmazemService>();

builder.Services.AddScoped<IControleQualidadeRepository, ControleQualidadeRepository>();
builder.Services.AddScoped<IControleQualidadeService, ControleQualidadeService>();

builder.Services.AddScoped<IDevolucaoRepository, DevolucaoRepository>();
builder.Services.AddScoped<IDevolucaoService, DevolucaoService>();

builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();

builder.Services.AddScoped<IIntegracaoSistemaRepository, IntegracaoSistemaRepository>();
builder.Services.AddScoped<IIntegracaoSistemaService, IntegracaoSistemaService>();

builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IInventarioService, InventarioService>();

builder.Services.AddScoped<IPedidoCompraRepository, PedidoCompraRepository>();
builder.Services.AddScoped<IPedidoCompraService, PedidoCompraService>();

builder.Services.AddScoped<IPrevisaoDemandaRepository, PrevisaoDemandaRepository>();
builder.Services.AddScoped<IPrevisaoDemandaService, PrevisaoDemandaService>();

builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

builder.Services.AddScoped<ISegurancaConformidadeRepository, SegurancaConformidadeRepository>();
builder.Services.AddScoped<ISegurancaConformidadeService, SegurancaConformidadeService>();

// Configuração de Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroservicoEstoque.Api API", Version = "v1" });

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
