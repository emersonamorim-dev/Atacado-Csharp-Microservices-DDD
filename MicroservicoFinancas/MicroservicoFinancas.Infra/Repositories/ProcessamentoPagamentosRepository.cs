using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using MicroservicoFinancas.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroservicoFinancas.Infra.Repositories
{
    public class ProcessamentoPagamentosRepository : IProcessamentoPagamentosRepository
    {
        private readonly IMongoCollection<ProcessamentoPagamentos> _processamentoPagamentosCollection;

        public ProcessamentoPagamentosRepository(IOptions<ProcessamentoPagamentosDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _processamentoPagamentosCollection = mongoDatabase.GetCollection<ProcessamentoPagamentos>(settings.Value.CollectionName);
        }

        public async Task<List<ProcessamentoPagamentos>> GetProcessamentosPagamentosAsync() =>
            await _processamentoPagamentosCollection.Find(x => true).ToListAsync();

        public async Task<ProcessamentoPagamentos> CreateProcessamentoPagamentosAsync(ProcessamentoPagamentos processamentoPagamentos)
        {
            await _processamentoPagamentosCollection.InsertOneAsync(processamentoPagamentos);
            return processamentoPagamentos;
        }

        public async Task<ProcessamentoPagamentos> UpdateProcessamentoPagamentosAsync(ProcessamentoPagamentos processamentoPagamentos)
        {
            await _processamentoPagamentosCollection.ReplaceOneAsync(x => x.Id == processamentoPagamentos.Id, processamentoPagamentos);
            return processamentoPagamentos;
        }

        public async Task DeleteProcessamentoPagamentosAsync(string processamentoPagamentosId)
        {
            await _processamentoPagamentosCollection.DeleteOneAsync(x => x.Id == processamentoPagamentosId);
        }
    }
}
