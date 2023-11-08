using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using MicroservicoFinancas.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Infra.Repositories
{
    public class PlanejamentoFinanceiroRepository : IPlanejamentoFinanceiroRepository
    {
        private readonly IMongoCollection<PlanejamentoFinanceiro> _planejamentoFinanceiroCollection;

        public PlanejamentoFinanceiroRepository(IOptions<PlanejamentoFinanceiroDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _planejamentoFinanceiroCollection = mongoDatabase.GetCollection<PlanejamentoFinanceiro>(settings.Value.CollectionName);
        }

        public async Task<List<PlanejamentoFinanceiro>> GetPlanejamentosFinanceirosAsync() =>
            await _planejamentoFinanceiroCollection.Find(x => true).ToListAsync();

        public async Task<PlanejamentoFinanceiro> CreatePlanejamentoFinanceiroAsync(PlanejamentoFinanceiro planejamentoFinanceiro)
        {
            await _planejamentoFinanceiroCollection.InsertOneAsync(planejamentoFinanceiro);
            return planejamentoFinanceiro;
        }

        public async Task<PlanejamentoFinanceiro> UpdatePlanejamentoFinanceiroAsync(PlanejamentoFinanceiro planejamentoFinanceiro)
        {
            await _planejamentoFinanceiroCollection.ReplaceOneAsync(x => x.Id == planejamentoFinanceiro.Id, planejamentoFinanceiro);
            return planejamentoFinanceiro;
        }

        public async Task DeletePlanejamentoFinanceiroAsync(string id)
        {
            await _planejamentoFinanceiroCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
