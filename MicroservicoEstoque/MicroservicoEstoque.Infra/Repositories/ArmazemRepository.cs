using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class ArmazemRepository : IArmazemRepository
    {
        private readonly IMongoCollection<Armazem> _armazemCollection;

        public ArmazemRepository(IOptions<ArmazemDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _armazemCollection = mongoDatabase.GetCollection<Armazem>(settings.Value.CollectionName);
        }

        public async Task<List<Armazem>> GetArmazemAsync() =>
            await _armazemCollection.Find(x => true).ToListAsync();

        public async Task<Armazem> CreateArmazemAsync(Armazem armazem)
        {
            await _armazemCollection.InsertOneAsync(armazem);
            return armazem;
        }

        public async Task<Armazem> UpdateArmazemAsync(Armazem armazem)
        {
            await _armazemCollection.ReplaceOneAsync(x => x.Id == armazem.Id, armazem);
            return armazem;
        }

        public async Task DeleteArmazemAsync(string armazemId)
        {
            await _armazemCollection.DeleteOneAsync(x => x.Id == armazemId);
        }

    }
}
