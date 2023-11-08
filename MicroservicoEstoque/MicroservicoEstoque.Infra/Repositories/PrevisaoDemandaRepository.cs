using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class PrevisaoDemandaRepository : IPrevisaoDemandaRepository
    {
        private readonly IMongoCollection<PrevisaoDemanda> _previsaoDemandaCollection;

        public PrevisaoDemandaRepository(IOptions<PrevisaoDemandaDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _previsaoDemandaCollection = mongoDatabase.GetCollection<PrevisaoDemanda>(settings.Value.CollectionName);
        }

        public async Task<List<PrevisaoDemanda>> GetPrevisaoDemandaAsync() =>
            await _previsaoDemandaCollection.Find(x => true).ToListAsync();

        public async Task<PrevisaoDemanda> CreatePrevisaoDemandaAsync(PrevisaoDemanda previsaoDemanda)
        {
            await _previsaoDemandaCollection.InsertOneAsync(previsaoDemanda);
            return previsaoDemanda;
        }

        public async Task<PrevisaoDemanda> UpdatePrevisaoDemandaAsync(PrevisaoDemanda previsaoDemanda)
        {
            await _previsaoDemandaCollection.ReplaceOneAsync(x => x.Id == previsaoDemanda.Id, previsaoDemanda);
            return previsaoDemanda;
        }

        public async Task DeletePrevisaoDemandaAsync(string previsaoDemandaId)
        {
            await _previsaoDemandaCollection.DeleteOneAsync(x => x.Id == previsaoDemandaId);
        }
    }
}
