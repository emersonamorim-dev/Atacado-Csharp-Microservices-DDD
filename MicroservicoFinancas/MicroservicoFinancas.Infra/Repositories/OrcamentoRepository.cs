using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using MicroservicoFinancas.Infra.Data;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MicroservicoFinancas.Infra.Repositories
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly IMongoCollection<Orcamento> _orcamentoCollection;

        public OrcamentoRepository(IOptions<OrcamentoDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _orcamentoCollection = mongoDatabase.GetCollection<Orcamento>(settings.Value.CollectionName);
        }

        public async Task<List<Orcamento>> GetOrcamentosAsync() =>
            await _orcamentoCollection.Find(x => true).ToListAsync();

        public async Task<Orcamento> CreateOrcamentoAsync(Orcamento orcamento)
        {
            await _orcamentoCollection.InsertOneAsync(orcamento);
            return orcamento;
        }

        public async Task DeleteOrcamentoAsync(string orcamentoId)
        {
            await _orcamentoCollection.DeleteOneAsync(x => x.Id == orcamentoId);
        }

        public async Task<Orcamento> UpdateOrcamentoAsync(Orcamento orcamento)
        {
            await _orcamentoCollection.ReplaceOneAsync(x => x.Id == orcamento.Id, orcamento);
            return orcamento;
        }
    }
}
