using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class PedidoCompraRepository : IPedidoCompraRepository
    {
        private readonly IMongoCollection<PedidoCompra> _pedidoCompraCollection;

        public PedidoCompraRepository(IOptions<PedidoCompraDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _pedidoCompraCollection = mongoDatabase.GetCollection<PedidoCompra>(settings.Value.CollectionName);
        }

        public async Task<List<PedidoCompra>> GetPedidoCompraAsync() =>
            await _pedidoCompraCollection.Find(x => true).ToListAsync();

        public async Task<PedidoCompra> CreatePedidoCompraAsync(PedidoCompra pedidoCompra)
        {
            await _pedidoCompraCollection.InsertOneAsync(pedidoCompra);
            return pedidoCompra;
        }

        public async Task<PedidoCompra> UpdatePedidoCompraAsync(PedidoCompra pedidoCompra)
        {
            await _pedidoCompraCollection.ReplaceOneAsync(x => x.Id == pedidoCompra.Id, pedidoCompra);
            return pedidoCompra;
        }

        public async Task DeletePedidoCompraAsync(string pedidoCompraId)
        {
            await _pedidoCompraCollection.DeleteOneAsync(x => x.Id == pedidoCompraId);
        }
    }
}
