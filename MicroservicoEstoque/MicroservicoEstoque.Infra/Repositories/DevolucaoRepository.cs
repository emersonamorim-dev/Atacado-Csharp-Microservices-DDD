using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class DevolucaoRepository : IDevolucaoRepository
    {
        private readonly IMongoCollection<Devolucao> _devolucaoCollection;

        public DevolucaoRepository(IOptions<DevolucaoDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _devolucaoCollection = mongoDatabase.GetCollection<Devolucao>(settings.Value.CollectionName);
        }

        public async Task<List<Devolucao>> GetDevolucaoAsync() =>
            await _devolucaoCollection.Find(x => true).ToListAsync();

        public async Task<Devolucao> CreateDevolucaoAsync(Devolucao devolucao)
        {
            await _devolucaoCollection.InsertOneAsync(devolucao);
            return devolucao;
        }

        public async Task<Devolucao> UpdateDevolucaoAsync(Devolucao devolucao)
        {
            await _devolucaoCollection.ReplaceOneAsync(x => x.Id == devolucao.Id, devolucao);
            return devolucao;
        }

        public async Task DeleteDevolucaoAsync(string devolucaoId)
        {
            await _devolucaoCollection.DeleteOneAsync(x => x.Id == devolucaoId);
        }
    }
}
