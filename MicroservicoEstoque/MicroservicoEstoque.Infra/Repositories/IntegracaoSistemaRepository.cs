using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class IntegracaoSistemaRepository : IIntegracaoSistemaRepository
    {
        private readonly IMongoCollection<IntegracaoSistema> _integracaoSistemaCollection;

        public IntegracaoSistemaRepository(IOptions<IntegracaoSistemaDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _integracaoSistemaCollection = mongoDatabase.GetCollection<IntegracaoSistema>(settings.Value.CollectionName);
        }

        public async Task<List<IntegracaoSistema>> GetIntegracaoSistemaAsync() =>
            await _integracaoSistemaCollection.Find(x => true).ToListAsync();

        public async Task<IntegracaoSistema> CreateIntegracaoSistemaAsync(IntegracaoSistema integracaoSistema)
        {
            await _integracaoSistemaCollection.InsertOneAsync(integracaoSistema);
            return integracaoSistema;
        }

        public async Task<IntegracaoSistema> UpdateIntegracaoSistemaAsync(IntegracaoSistema integracaoSistema)
        {
            await _integracaoSistemaCollection.ReplaceOneAsync(x => x.Id == integracaoSistema.Id, integracaoSistema);
            return integracaoSistema;
        }

        public async Task DeleteIntegracaoSistemaAsync(string integracaoSistemaId)
        {
            await _integracaoSistemaCollection.DeleteOneAsync(x => x.Id == integracaoSistemaId);
        }
    }
}
