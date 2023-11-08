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
    public class AutomacaoProcessosRepository : IAutomacaoProcessosRepository
    {
        private readonly IMongoCollection<AutomacaoProcessos> _automacaoProcessosCollection;

        public AutomacaoProcessosRepository(IOptions<AutomacaoProcessosDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _automacaoProcessosCollection = mongoDatabase.GetCollection<AutomacaoProcessos>(settings.Value.CollectionName);
        }

        public async Task<List<AutomacaoProcessos>> GetAutomacaoProcessosAsync() =>
            await _automacaoProcessosCollection.Find(x => true).ToListAsync();

        public async Task<AutomacaoProcessos> CreateAutomacaoProcessosAsync(AutomacaoProcessos automacaoProcessos)
        {
            await _automacaoProcessosCollection.InsertOneAsync(automacaoProcessos);
            return automacaoProcessos;
        }

        public async Task<AutomacaoProcessos> UpdateAutomacaoProcessosAsync(AutomacaoProcessos automacaoProcessos)
        {
            await _automacaoProcessosCollection.ReplaceOneAsync(x => x.Id == automacaoProcessos.Id, automacaoProcessos);
            return automacaoProcessos;
        }

        public async Task DeleteAutomacaoProcessosAsync(string id)
        {
            await _automacaoProcessosCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}

