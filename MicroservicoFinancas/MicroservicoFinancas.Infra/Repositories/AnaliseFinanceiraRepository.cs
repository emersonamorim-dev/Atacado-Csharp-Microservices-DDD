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
    public class AnaliseFinanceiraRepository : IAnaliseFinanceiraRepository
    {
        private readonly IMongoCollection<AnaliseFinanceira> _analiseFinanceiraCollection;

        public AnaliseFinanceiraRepository(IOptions<AnaliseFinanceiraDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _analiseFinanceiraCollection = mongoDatabase.GetCollection<AnaliseFinanceira>(settings.Value.CollectionName);
        }

        public async Task<List<AnaliseFinanceira>> GetAnalisesFinanceirasAsync() =>
            await _analiseFinanceiraCollection.Find(x => true).ToListAsync();

        public async Task<AnaliseFinanceira> CreateAnaliseFinanceiraAsync(AnaliseFinanceira analiseFinanceira)
        {
            await _analiseFinanceiraCollection.InsertOneAsync(analiseFinanceira);
            return analiseFinanceira;
        }

        public async Task<AnaliseFinanceira> UpdateAnaliseFinanceiraAsync(AnaliseFinanceira analiseFinanceira)
        {
            await _analiseFinanceiraCollection.ReplaceOneAsync(x => x.Id == analiseFinanceira.Id, analiseFinanceira);
            return analiseFinanceira;
        }

        public async Task DeleteAnaliseFinanceiraAsync(string analiseFinanceiraId)
        {
            await _analiseFinanceiraCollection.DeleteOneAsync(x => x.Id == analiseFinanceiraId);
        }
    }
}
