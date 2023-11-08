using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly IMongoCollection<Inventario> _inventarioCollection;

        public InventarioRepository(IOptions<InventarioDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _inventarioCollection = mongoDatabase.GetCollection<Inventario>(settings.Value.CollectionName);
        }

        public async Task<List<Inventario>> GetInventarioAsync() =>
            await _inventarioCollection.Find(x => true).ToListAsync();

        public async Task<Inventario> CreateInventarioAsync(Inventario inventario)
        {
            await _inventarioCollection.InsertOneAsync(inventario);
            return inventario;
        }

        public async Task<Inventario> UpdateInventarioAsync(Inventario inventario)
        {
            await _inventarioCollection.ReplaceOneAsync(x => x.Id == inventario.Id, inventario);
            return inventario;
        }

        public async Task DeleteInventarioAsync(string inventarioId)
        {
            await _inventarioCollection.DeleteOneAsync(x => x.Id == inventarioId);
        }
    }
}
