using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;
using MongoDB.Driver;
using MicroservicoCompras.Infra.Interfaces;
using Microsoft.Extensions.Options;
using MicroservicoCompras.Infra.Data;
using MicroservicoCompras.Domain.Interfaces;

namespace MicroservicoCompras.Infra.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly IMongoCollection<Pedidos> _pedidosCollection;

        public PedidosRepository(IOptions<PedidosDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _pedidosCollection = mongoDatabase.GetCollection<Pedidos>(settings.Value.CollectionName);
        }

        public async Task<List<Pedidos>> GetPedidoAsync() =>
            await _pedidosCollection.Find(x => true).ToListAsync();

        public async Task<Pedidos> CreatePedidoAsync(Pedidos pedido)
        {
            await _pedidosCollection.InsertOneAsync(pedido);
            return pedido;
        }

        public async Task DeletePedidoAsync(string pedidoId)
        {
            await _pedidosCollection.DeleteOneAsync(x => x.Id == pedidoId);
        }

        public async Task<Pedidos> UpdatePedidoAsync(Pedidos pedido)
        {
            await _pedidosCollection.ReplaceOneAsync(x => x.Id == pedido.Id, pedido);
            return pedido;
        }
    }
}
